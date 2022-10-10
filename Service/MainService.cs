using Blazored.LocalStorage;
using MCake.Data;
using MCake.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace MCake.Service
{
    public class MainService
    {
        public string Port = "https://mcakeadmin.herokuapp.com";
        private readonly ILocalStorageService _store;
        private readonly ProductCollectionsController _collection;
        private readonly CartsController _cart;
        private readonly ApplicationDbContext _context;
        private readonly CartDbContext _db;
        private readonly CollectionDbContext _col;
        private readonly NavCollectionDbContext _nav;
        private readonly IHttpContextAccessor _state;
        private readonly UserManager<IdentityUser> _user;

        public BehaviorSubject<List<ProductCollection>> CartItems = new BehaviorSubject<List<ProductCollection>>(null);
        public BehaviorSubject<string> CartId = new BehaviorSubject<string>(null);

        public MainService(ApplicationDbContext context, NavCollectionDbContext nav, CollectionDbContext col, CartDbContext db, UserManager<IdentityUser> user, IHttpContextAccessor state, CartsController cart, ProductCollectionsController collectionController, ILocalStorageService store)
        {
            _context = context;
            _nav = nav;
            _col = col;
            _db = db;
            _user = user;
            _state = state;
            _cart = cart;
            _collection = collectionController;
            _store = store;
        }


        public async Task<BehaviorSubject<string>> Persist_user()
        {
            var ci = new BehaviorSubject<string>(null);
            var s = _state.HttpContext.User.Identity.Name;
            ci.OnNext(s);
            return ci;
        }


        public async Task<BehaviorSubject<string>> NewCartAsync()
        {
            var ci = new BehaviorSubject<string>(null);
            var u = await Persist_user();
            u.Subscribe(async r =>
            {
                if (r != null)
                {
                    var u = new Cart { User = r, Stamp = DateTime.Now };
                    var req = await _cart.PostCart(u);
                    ci.OnNext(req.CartId.ToString());
                }
            });

            return ci;
        }

        public async Task AddCartAsync(Guid C, Product P)
        {
            var pro = new ProductCollection
            {
                CartId = C,
                ProductId = P.ProductId,
                ProductName = P.ProductName,
                Price = P.Price,
                Quantity = "1",
                Image_1 = P.Image_1,
                Image_2 = P.Image_2,
                ShippingPrice = P.ShippingPrice,
                Description = P.Description,
                Rating = P.Rating,
                Tag = P.Tag
            };

            await _collection.PostProductCollection(pro);
            await GetCartItemsAsync(C);

        }

        public async Task<BehaviorSubject<string>> CheckCartAsync()
        {
            var u = await Persist_user();
            var ci = new BehaviorSubject<string>(null);
            u.Subscribe(async r =>
            {
                if (r != null)
                {
                    var c = _db.Cart.Where(s => s.User.Contains(r)).Select(s => s.CartId).SingleOrDefault();
                    if (c.ToString() == "00000000-0000-0000-0000-000000000000")
                    {
                        var i = await NewCartAsync();
                        i.Subscribe(r =>
                        {
                            ci.OnNext(r);
                        });

                    }
                    else
                    {
                        ci.OnNext(c.ToString());

                    }
                }
            });



            return ci;
        }

        public async Task<BehaviorSubject<List<ProductCollection>>> GetCartItemsAsync(Guid C)
        {
            var ci = new BehaviorSubject<List<ProductCollection>>(null);
            if (C.ToString() != "00000000-0000-0000-0000-000000000000")
            {
                var pro = await _col.ProductCollections.Where(s => C.ToString().Contains(s.CartId.ToString())).ToListAsync();
                ci.OnNext(pro);

            }


            return ci;
        }


        public async Task<BehaviorSubject<string>> NavCheckCartAsync()
        {
            var u = await Persist_user();
            var ci = new BehaviorSubject<string>(null);
            u.Subscribe(async r =>
            {
                if (r != null)
                {
                    var c = _nav.Cart.Where(s => s.User.Contains(r)).Select(s => s.CartId).SingleOrDefault();
                    if (c.ToString() == "00000000-0000-0000-0000-000000000000")
                    {
                        var i = await NewCartAsync();
                        i.Subscribe(r =>
                        {
                            ci.OnNext(r);
                        });

                    }
                    else
                    {
                        ci.OnNext(c.ToString());

                    }
                }
            });



            return ci;
        }

        public async Task<BehaviorSubject<List<ProductCollection>>> NavGetCartItemsAsync(Guid C)
        {
            var ci = new BehaviorSubject<List<ProductCollection>>(null);
            if (C.ToString() != "00000000-0000-0000-0000-000000000000")
            {
                var pro = await _nav.ProductCollections.Where(s => C.ToString().Contains(s.CartId.ToString())).ToListAsync();
                ci.OnNext(pro);
                CartItems.OnNext(pro);
            }


            return ci;
        }

        public async Task Logger(string Act)
        {
            var u = await Persist_user();
            u.Subscribe(async r =>
           {
               if (r != null)
               {
                   Activity data = new Activity();
                   data.UserId = r;
                   data.Action = Act;

                   await _context.Activities.AddAsync(data);
                   await _context.SaveChangesAsync();

               }
           });

        }
    }
}

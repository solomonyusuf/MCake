using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCake.Data;
using MCake.Models;
using System.Reactive.Subjects;
using Blazored.LocalStorage;

namespace MCake.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly CartDbContext _context;
        private readonly ILocalStorageService _store;

        public CartsController(CartDbContext context, ProductCollectionsController collectionController, ILocalStorageService store)
        {
            _context = context;
            _store = store;
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCart()
        {
            return await _context.Cart.ToListAsync();
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<Cart> GetCart(Guid id)
        {
            var cart = await _context.Cart.FindAsync(id);

            if (cart == null)
            {
                return null;
            }

            return cart;
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(Guid id, Cart cart)
        {
            if (id != cart.CartId)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Cart> PostCart(Cart cart)
        {
            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();

            return await GetCart(cart.CartId);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(Guid id)
        {
            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartExists(Guid id)
        {
            return _context.Cart.Any(e => e.CartId == id);
        }



    }
}

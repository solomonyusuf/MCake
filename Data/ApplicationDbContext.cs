using MCake.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCake.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Initial> Initials { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<CheckOut> CheckOuts { get; set; }
        public virtual DbSet<ApplicationUser> User { get; set; }
        public virtual DbSet<Pay> Payment { get; set; }



    }

    public class CartDbContext : DbContext
    {
        public CartDbContext(DbContextOptions<CartDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<WishCollection> WishCollections { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }
    }

    public class CollectionDbContext : DbContext
    {
        public CollectionDbContext(DbContextOptions<CollectionDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ProductCollection> ProductCollections { get; set; }
    }
    public class NavCollectionDbContext : DbContext
    {
        public NavCollectionDbContext(DbContextOptions<NavCollectionDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<ProductCollection> ProductCollections { get; set; }
    }
}

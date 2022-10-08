using System;
using System.ComponentModel.DataAnnotations;

namespace MCake.Models
{
    public class Wishlist
    {
        [Key]
        public virtual Guid WishlistId { get; set; }
        public virtual string UserId { get; set; }
    }
}

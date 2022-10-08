using System;
using System.ComponentModel.DataAnnotations;

namespace MCake.Models
{
    public class WishCollection
    {
        [Key]
        public virtual Guid WishCollectionId { get; set; }
        public virtual Guid WishlistId { get; set; }
        public virtual Guid ProductId { get; set; }

    }
}

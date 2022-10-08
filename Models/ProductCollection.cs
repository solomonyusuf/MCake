using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCake.Models
{
    public class ProductCollection
    {
        [Key]
        public virtual Guid ProductCollectionId { get; set; }
        public virtual Guid CartId { get; set; }
        public virtual Guid ProductId { get; set; }
        public virtual string Image_1 { get; set; }
        public virtual string Image_2 { get; set; }
        public virtual string Quantity { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string Description { get; set; }
        public virtual string Tag { get; set; }
        public virtual string Price { get; set; }
        public virtual string ShippingPrice { get; set; }
        public virtual int Rating { get; set; }
    }
}

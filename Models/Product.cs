using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCake.Models
{
    public class Product
    {
        [Key]
        public virtual Guid ProductId { get; set; }
        public virtual Guid CategoryId { get; set; }
        public virtual string Image_1 { get; set; }
        public virtual string Image_2 { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string Description { get; set; }
        public virtual string Tag { get; set; }
        public virtual string Price { get; set; }
        public virtual string ShippingPrice { get; set; }
        public virtual int Rating { get; set; }
        public virtual DateTime DateTime { get; set; }
        public Product()
        {
            DateTime = DateTime.Now;

        }

    }
}

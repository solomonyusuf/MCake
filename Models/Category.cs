using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MCake.Models
{
    public class Category
    {
        [Key]
        public virtual Guid CategoryId { get; set; }
        public virtual byte[] ImagePath { get; set; }
        public virtual string Content { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual Collection<Product> Products { get; set; }
        public Category()
        {
            Products = new Collection<Product>();
        }
    }
}

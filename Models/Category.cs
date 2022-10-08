using System;
using System.ComponentModel.DataAnnotations;

namespace MCake.Models
{
    public class Category
    {
        [Key]
        public virtual Guid CategoryId { get; set; }
        public virtual string ImagePath { get; set; }
        public virtual string CategoryName { get; set; }
    }
}

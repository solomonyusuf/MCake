using System;
using System.ComponentModel.DataAnnotations;

namespace MCake.Models
{
    public class Image
    {
        [Key]
        public virtual Guid ImageId { get; set; }
        public virtual Guid ProductId { get; set; }
        public virtual string ImagePath { get; set; }
    }
}

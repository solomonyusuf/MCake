using System;
using System.ComponentModel.DataAnnotations;

namespace MCake.Models
{
    public class Review
    {
        [Key]
        public virtual Guid ReviewId { get; set; }
        public virtual Guid ProductId { get; set; }
        public virtual string UserId { get; set; }
        public virtual string Tag { get; set; }
        public virtual string Comment { get; set; }
        public virtual int Star { get; set; }
        public virtual int Helpful { get; set; }
        public virtual int Unhelpful { get; set; }
    }
}

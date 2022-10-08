using System;
using System.ComponentModel.DataAnnotations;

namespace MCake.Models
{
    public class Pay
    {
        [Key]
        public virtual Guid PayId { get; set; }
        public virtual string UserId { get; set; }
    }
}

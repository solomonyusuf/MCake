using System;
using System.ComponentModel.DataAnnotations;

namespace MCake.Models
{
    public class CheckOut
    {
        [Key]
        public Guid CheckOutId { get; set; }
        public string User { get; set; }
        public Guid OrderId { get; set; }
        public DateTime DateTime { get; set; }
        public CheckOut()
        {
            DateTime = DateTime.Now;
        }
    }
}

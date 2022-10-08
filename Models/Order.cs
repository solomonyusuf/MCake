using System;
using System.ComponentModel.DataAnnotations;

namespace MCake.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid CartId { get; set; }
        public virtual string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string OrderNote { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string TotalPrice { get; set; }
        public bool PaymentConfirmed { get; set; }
        public DateTime DateTime { get; set; }
        public Order()
        {
            DateTime = DateTime.Now;
        }
    }
}

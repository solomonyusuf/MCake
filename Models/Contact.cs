using System;

namespace MCake.Models
{
    public class Contact
    {
        public virtual int Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Tag { get; set; }
        public virtual string PhoneNo { get; set; }
        public virtual string Message { get; set; }
        public virtual DateTime DateTime { get; set; }
        public Contact()
        {
            DateTime = DateTime.Now;
        }
    }
}

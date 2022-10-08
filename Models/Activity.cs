using System;
using System.ComponentModel.DataAnnotations;

namespace MCake.Models
{
    public class Activity
    {
        [Key]
        public virtual int ActivityId { get; set; }
        public virtual string UserId { get; set; }
        public virtual string Action { get; set; }
        public virtual DateTime DateTime { get; set; }
        public Activity()
        {
            DateTime = DateTime.Now;
        }
    }
}

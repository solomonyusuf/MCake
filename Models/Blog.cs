using System;

namespace MCake.Models
{
    public class Blog
    {
        public virtual int Id { get; set; }
        public virtual byte[] ImagePath { get; set; }
        public virtual string Content { get; set; }
        public virtual string Title { get; set; }
        public virtual string Body { get; set; }
        public virtual DateTime Time { get; set; }

        public Blog()
        {
            Time = DateTime.Now;
        }
    }
}

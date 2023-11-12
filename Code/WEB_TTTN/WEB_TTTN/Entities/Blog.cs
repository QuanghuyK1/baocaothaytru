using System;
using System.Collections.Generic;

namespace WEB_TTTN.Entities
{
    public partial class Blog
    {
        public Blog()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Username { get; set; } = null!;
        public int Status { get; set; }

        public virtual Account UsernameNavigation { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
    }
}

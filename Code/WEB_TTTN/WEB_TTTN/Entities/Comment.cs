using System;
using System.Collections.Generic;

namespace WEB_TTTN.Entities
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
        public int Blogid { get; set; }

        public virtual Blog Blog { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace WEB_TTTN.Entities
{
    public partial class TypeService
    {
        public TypeService()
        {
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public int Price { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}

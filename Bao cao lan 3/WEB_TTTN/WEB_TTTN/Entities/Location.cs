using System;
using System.Collections.Generic;

namespace WEB_TTTN.Entities
{
    public partial class Location
    {
        public Location()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Img { get; set; } = null!;

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}

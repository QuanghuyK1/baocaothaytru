using System;
using System.Collections.Generic;

namespace WEB_TTTN.Entities
{
    public partial class Nation
    {
        public Nation()
        {
            Medicines = new HashSet<Medicine>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}

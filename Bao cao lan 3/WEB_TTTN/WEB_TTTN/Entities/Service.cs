using System;
using System.Collections.Generic;

namespace WEB_TTTN.Entities
{
    public partial class Service
    {
        public Service()
        {
            MedicineBills = new HashSet<MedicineBill>();
        }

        public int Id { get; set; }
        public int PatientId { get; set; }
        public int EmployeeId { get; set; }
        public int TypeServiceId { get; set; }
        public string? Decription { get; set; }
        public DateTime GetDate { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
        public virtual TypeService TypeService { get; set; } = null!;
        public virtual ICollection<MedicineBill> MedicineBills { get; set; }
    }
}

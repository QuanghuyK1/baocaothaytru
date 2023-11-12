using System;
using System.Collections.Generic;

namespace WEB_TTTN.Entities
{
    public partial class Medicine
    {
        public Medicine()
        {
            MedicineBills = new HashSet<MedicineBill>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Usedate { get; set; }
        public string Description { get; set; } = null!;
        public int Nationid { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public DateTime Getdate { get; set; }
        public int HandlePrice { get; set; }
        public int Startus { get; set; }
        public string Img { get; set; } = null!;

        public virtual Nation Nation { get; set; } = null!;
        public virtual ICollection<MedicineBill> MedicineBills { get; set; }
    }
}

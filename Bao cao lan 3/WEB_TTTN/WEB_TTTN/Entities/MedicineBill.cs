using System;
using System.Collections.Generic;

namespace WEB_TTTN.Entities
{
    public partial class MedicineBill
    {
        public int Id { get; set; }
        public string BillCode { get; set; }    
        public int Medicineid { get; set; }
        public int Serviceid { get; set; }
        public int Count { get; set; }
        public int TotalPrice { get; set; }
        public int Status { get; set; }

        public virtual Medicine Medicine { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
    }
}

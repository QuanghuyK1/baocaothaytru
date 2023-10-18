using System;
using System.Collections.Generic;

namespace WEB_TTTN.Entities
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public string Eventname { get; set; } = null!;
        public DateTime Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public int? Locationid { get; set; }
        public string Description { get; set; } = null!;
        public int? Patientid { get; set; }
        public int? Employeeid { get; set; }
        public int Status { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Location? Location { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}

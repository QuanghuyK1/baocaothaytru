using System;
using System.Collections.Generic;

namespace WEB_TTTN.Entities
{
    public partial class HospitalHealthInsurance
    {
        public HospitalHealthInsurance()
        {
            Patients = new HashSet<Patient>();
        }

        public string InsuranceId { get; set; } = null!;
        public string HospitalName { get; set; } = null!;
        public int? Fee { get; set; }
        public DateTime Usedate { get; set; }
        public int? Startus { get; set; }
        public string? Img { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? Createday { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}

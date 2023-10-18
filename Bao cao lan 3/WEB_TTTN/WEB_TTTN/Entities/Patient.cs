using System;
using System.Collections.Generic;

namespace WEB_TTTN.Entities
{
    public partial class Patient
    {
        public Patient()
        {
            Schedules = new HashSet<Schedule>();
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? InsuranceId { get; set; }
        public string? Username { get; set; }
        public string? Address { get; set; }
        public string? Img { get; set; }

        public virtual HospitalHealthInsurance? Insurance { get; set; }
        public virtual Account UsernameNavigation { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}

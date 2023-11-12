using System;
using System.Collections.Generic;

namespace WEB_TTTN.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Certificates = new HashSet<Certificate>();
            Schedules = new HashSet<Schedule>();
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? ClassId { get; set; }
        public string Username { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public string? Description { get; set; }
        public string? Identification { get; set; }
        public int? Status { get; set; }
        public string? Address { get; set; }
        public int? SalaryBasic { get; set; }
        public string? Img { get; set; }
        public int? EmployeeRoleId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual EmployeeRole? EmployeeRole { get; set; }
        public virtual Account UsernameNavigation { get; set; } = null!;
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}

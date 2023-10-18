using System;
using System.Collections.Generic;

namespace WEB_TTTN.Entities
{
    public partial class Account
    {
        public Account()
        {
            Blogs = new HashSet<Blog>();
            Employees = new HashSet<Employee>();
            Patients = new HashSet<Patient>();
        }

        public string Username { get; set; } = null!;
        public string? Password { get; set; }
        public int RoleId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Status { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}

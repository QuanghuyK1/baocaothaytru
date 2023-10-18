using System;
using System.Collections.Generic;

namespace WEB_TTTN.Entities
{
    public partial class Class
    {
        public Class()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string ClassName { get; set; } = null!;
        public string Img { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Application.Models
{
    internal class EmpModels
    {

        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Classname { get; set; }
        public string Username { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public string? Description { get; set; }
        public string? Identification { get; set; }
        public int? Status { get; set; }
        public string? Address { get; set; }
        public int? SalaryBasic { get; set; }
        public string? Img { get; set; }
        public string? EmployeeRoleName
        {
            get; set;
        }
    }
}

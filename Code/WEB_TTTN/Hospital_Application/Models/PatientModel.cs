using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Application.Models
{
    internal class PatientModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? InsuranceId { get; set; }
        public string? Username { get; set; }
        public string Address { get; set; } = null!;
        public string? Img { get; set; }
    }
}

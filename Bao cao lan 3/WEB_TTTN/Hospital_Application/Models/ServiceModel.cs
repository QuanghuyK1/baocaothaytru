using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Application.Models
{
    internal class ServiceModel
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int TypeServiceId { get; set; }
        public string TypeServiceName { get; set; }
        public string EmpUsername { get; set; }
        public string? Decription { get; set; }
        public DateTime GetDate { get; set; }
    }
}

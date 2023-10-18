using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Application.Models
{
    internal class InputMedicineBill
    {
        public string MedName { get; set; }
        public int Count { get; set; }

        public int ServiceId { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }

        public int Status { get; set; }
    }
}

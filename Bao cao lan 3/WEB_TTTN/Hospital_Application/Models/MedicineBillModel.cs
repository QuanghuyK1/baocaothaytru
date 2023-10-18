using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Application.Models
{
    internal class MedicineBillModel
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public int Serviceid { get; set; }
        public int PriceMed { get; set; }
        public int Count { get; set; }
        public int TotalPrice { get; set; }
        public int Status { get; set; }

        public string Img { get; set; }
    }
}

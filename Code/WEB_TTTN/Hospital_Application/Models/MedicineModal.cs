using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Application.Models
{
    internal class MedicineModal
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Usedate { get; set; }
        public string Description { get; set; } = null!;
        public int Count { get; set; }
        public int Price { get; set; }
        public DateTime Getdate { get; set; }
        public int HandlePrice { get; set; }
        public int Startus { get; set; }
        public string Img { get; set; } = null!;

        public string nationname { get; set; }
    }
}

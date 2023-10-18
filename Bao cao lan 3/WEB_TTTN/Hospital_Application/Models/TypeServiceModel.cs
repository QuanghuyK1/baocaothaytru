using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Application.Models
{
    internal class TypeServiceModel
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public int Price { get; set; }
        public int? Status { get; set; }
    }
}

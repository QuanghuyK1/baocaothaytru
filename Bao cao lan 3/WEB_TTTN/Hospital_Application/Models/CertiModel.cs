using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Application.Models
{
    internal class CertiModel
    {
        public int Id {  get; set; }
        public string CertificateName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Usedate { get; set; }
        public string Img { get; set; } = null!;
    }
}

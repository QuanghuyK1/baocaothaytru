using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Application.Models
{
    internal class ChangePassModel
    {
        public string OldPass { get; set; }
        public string NewPass { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

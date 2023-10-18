using System;
using System.Collections.Generic;

namespace WEB_TTTN.Entities
{
    public partial class Certificate
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string CertificateName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Usedate { get; set; }
        public string Img { get; set; } = null!;

        public virtual Employee Person { get; set; } = null!;
    }
}

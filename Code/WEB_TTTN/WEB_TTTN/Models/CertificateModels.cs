namespace WEB_TTTN.Models
{
    public class CertificateModels
    {
        public int Id { get; set; }
        public string CertificateName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Usedate { get; set; }
        public string Img { get; set; } = null!;
    }
}

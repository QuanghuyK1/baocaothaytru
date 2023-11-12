using WEB_TTTN.Entities;

namespace WEB_TTTN.Models
{
    public class PatientModels
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

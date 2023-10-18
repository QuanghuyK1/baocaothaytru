namespace WEB_TTTN.Models
{
    public class UpdatePatientModels
    {
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; } = null!;
    }
}

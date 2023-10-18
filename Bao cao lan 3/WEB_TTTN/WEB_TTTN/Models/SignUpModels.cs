using System.ComponentModel.DataAnnotations;

namespace WEB_TTTN.Models
{
    public class SignUpModels
    {
        [Required]
        public string Username { get; set; } = null!;
        
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConPassword { get; set; } = null!;
        [Required]
        public int RoleId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WEB_TTTN.Models
{
    public class SignInModels
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}

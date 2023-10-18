using Microsoft.AspNetCore.Identity;

namespace WEB_TTTN.Models
{
    public class AccountModels // Kiểu dữ liệu của khóa chính là string
    {
        // Các thuộc tính khác của bảng Account
        public string Username { get; set; } = null!;
        public string? Password { get; set; }
        public int RoleId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}

namespace WEB_TTTN.Models
{
    public class BlogModels
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Username { get; set; } = null!;
        public int Status { get; set; }
    }
}

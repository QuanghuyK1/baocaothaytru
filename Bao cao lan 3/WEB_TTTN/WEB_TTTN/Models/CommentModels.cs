using WEB_TTTN.Entities;

namespace WEB_TTTN.Models
{
    public class CommentModels
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
        public int Blogid { get; set; }

        public virtual Blog Blog { get; set; } = null!;
    }
}

using WEB_TTTN.Entities;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public interface IBlogRepository
    {
        public Task InsertBlog(BlogModels model);
        public Task UpdateBlog(BlogModels model,int id);

        public Task DeleteBlog(int id);
        public Task<BlogModels> GetBlog(int id);
        public Task<List<Blog>> GetListBlog();

        public Task<List<Blog>> GetListBlogByUsername(string username);
    }
}

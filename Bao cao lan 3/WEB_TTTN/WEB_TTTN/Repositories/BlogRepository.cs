using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using WEB_TTTN.Entities;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly HospitalDatabaseContext _context;
        private readonly IMapper _mapper;
        public BlogRepository(HospitalDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task DeleteBlog(int id)
        {
            var blog = await _context.Blogs.SingleOrDefaultAsync(b => b.Id == id);
            blog.Status = 0;
            await _context.SaveChangesAsync();
        }

        public async Task<BlogModels> GetBlog(int id)
        {
            var blog = await _context.Blogs.SingleOrDefaultAsync(b => b.Id == id);
            return _mapper.Map<BlogModels>(blog);

        }

        public async Task<List<Blog>> GetListBlog()
        {
            var blog = await _context.Blogs.ToListAsync();
            return blog;
        }

        public async Task<List<Blog>> GetListBlogByUsername(string username)
        {
            var blog = await _context.Blogs.Where(b => b.Username == username && b.Status != 0).ToListAsync();
            return blog;
        }

        public async Task InsertBlog(BlogModels model)
        {
            var blog = _mapper.Map<Blog>(model);
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBlog(BlogModels model,int id)
        {
            var blog = await _context.Blogs.SingleOrDefaultAsync(b => b.Id == id);
            blog.Name = model.Name;
            blog.Description = model.Description;
            await _context.SaveChangesAsync();
        }

    }
}

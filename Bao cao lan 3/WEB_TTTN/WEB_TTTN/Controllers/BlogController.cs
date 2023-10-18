using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WEB_TTTN.Entities;
using WEB_TTTN.Helpers;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;
using WEB_TTTN.Repositories;

namespace WEB_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly HospitalDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IBlogRepository _blogRepository;
        public BlogController(HospitalDatabaseContext context, IConfiguration configuration, IBlogRepository blogRepository)
        {
            _context = context;
            _configuration = configuration;
            _blogRepository = blogRepository;
        }
        [HttpGet("GetBlog/{id}")]
        [Authorize]
        public async Task<IActionResult> GetBlog([FromRoute] int id)
        {
            try
            {
                var username = User.Identity.Name;
                return Ok(await _blogRepository.GetBlog(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("DelBlog/{id}")]
        [Authorize]
        public async Task<IActionResult> DelBlog([FromRoute] int id)
        {
            try
            {
                var username = User.Identity.Name;
                await _blogRepository.DeleteBlog(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("UpBlog/{id}")]
        [Authorize]
        public async Task<IActionResult> DelBlog(InputBlog input, [FromRoute] int id)
        {
            try
            {
                var username = User.Identity.Name;
                var model = new BlogModels
                {
                    Name = input.Name,
                    Description = input.Description,
                    Username = username
                };
                await _blogRepository.UpdateBlog(model,id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("InsBlog")]
        [Authorize]
        public async Task<IActionResult> InsBlog(InputBlog input)
        {
            try
            {
                var username = User.Identity.Name;
                var model = new BlogModels
                {
                    Name = input.Name,
                    Description = input.Description,
                    Date = input.Date,
                    Username = username,
                    Status = 1
                };
                
                await _blogRepository.InsertBlog(model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("GetAllBlogByUsername")]
        [Authorize]
        public async Task<IActionResult> GetAllBlog()
        {
            try
            {
                var username = User.Identity.Name;
                
                return Ok(await _blogRepository.GetListBlogByUsername
                    (username));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("GetAllBlog")]
        public async Task<IActionResult> GetListBlog()
        {
            try
            {
                return Ok(await _blogRepository.GetListBlog());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

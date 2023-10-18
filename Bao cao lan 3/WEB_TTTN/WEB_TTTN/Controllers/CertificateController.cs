using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Entities;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;
using WEB_TTTN.Repositories;

namespace WEB_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly HospitalDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly ICertificateRepository _certificateRepository;
        public CertificateController(HospitalDatabaseContext context, IConfiguration configuration, ICertificateRepository certificateRepository)
        {
            _context = context;
            _configuration = configuration;
            _certificateRepository = certificateRepository;
        }
        [HttpGet("GetCertificate/{id}")]
        [Authorize]
        public async Task<IActionResult> GetCerti([FromRoute] int id)
        {
            try
            {
                var username = User.Identity.Name;
                return Ok(await _certificateRepository.GetCertificates(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("DelCerti/{id}")]
        [Authorize]
        public async Task<IActionResult> DelCerti([FromRoute] int id)
        {
            try
            {
                var username = User.Identity.Name;
                await _certificateRepository.DeleteCertificate(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("UpCerti/{id}")]
        [Authorize]
        public async Task<IActionResult> DelBlog([FromForm] string name, [FromForm] string des, [FromForm] DateTime usedate, [FromRoute] int id, [FromForm] IFormFile image)
        {
            try
            {
                var username = User.Identity.Name;
                if (image == null || image.Length == 0)
                {
                    return BadRequest("No image uploaded");
                }

                // Lưu ảnh vào thư mục trên server
                var imagePath = "D:\\TTTN\\WEB_TTTN\\WEB_TTTN\\ImagePath\\"; // Thay đổi đường dẫn tới thư mục lưu ảnh
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var fullPath = Path.Combine(imagePath, uniqueFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                CertificateModels model = new CertificateModels
                {
                    CertificateName = name,
                    Description = des,
                    Usedate = usedate,
                    Img = fullPath,
                };

                
                await _certificateRepository.UpdateCertificate(model, id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("InsCerti")]
        [Authorize]
        public async Task<IActionResult> InsCerti([FromForm] string name, [FromForm] string des, [FromForm] DateTime usedate, [FromForm] IFormFile image)
        {
            try
            {
                if (image == null || image.Length == 0)
                {
                    return BadRequest("No image uploaded");
                }

                // Lưu ảnh vào thư mục trên server
                var imagePath = "D:\\TTTN\\WEB_TTTN\\WEB_TTTN\\ImagePath\\"; // Thay đổi đường dẫn tới thư mục lưu ảnh
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                var fullPath = Path.Combine(imagePath, uniqueFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                var username = User.Identity.Name;
                CertificateModels model = new CertificateModels
                {
                    CertificateName = name,
                    Description = des,
                    Usedate = usedate,
                    Img = fullPath,
                };
                await _certificateRepository.InsertCertificate(model, username);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("GetAllCertiByUsername")]
        [Authorize]
        public async Task<IActionResult> GetAllCerti()
        {
            try
            {
                var username = User.Identity.Name;

                return Ok(await _certificateRepository.GetAllCertificates
                    (username));
            }
            catch
            {
                return BadRequest();
            }
        }
        
    }
}

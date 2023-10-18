using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using WEB_TTTN.Entities;
using WEB_TTTN.Helpers;
using WEB_TTTN.Models;
using WEB_TTTN.Repositories;

namespace WEB_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        private readonly HospitalDatabaseContext _context;
        public ProfileController(IProfileRepository repo,HospitalDatabaseContext context)
        {
            _profileRepository = repo;
            _context = context;
        }
        [HttpGet("AllSchedule")]
        [Authorize]
        public async Task<IActionResult> GetAllSchedule()
        {
            try
            {
                string username = User.Identity.Name;
                
                return Ok(await _profileRepository.GetAllSchedules(username));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordModels model)
        {
            try
            {
                // Get the current user's username from the token
                var username = User.Identity.Name;

                // Find the user in the database
                var user = await _context.Accounts.SingleOrDefaultAsync(u => u.Username == username);

                // Check if the old password matches the stored password
                bool isOldPasswordCorrect = BCrypt.Net.BCrypt.Verify(model.OldPass, user.Password);
                if (!isOldPasswordCorrect)
                {
                    return BadRequest("Incorrect old password.");
                }

                // Check if the new password and confirm password match
                if (model.NewPass != model.ConfirmPassword)
                {
                    return BadRequest("New password and confirm password do not match.");
                }

                // Update the password
                await _profileRepository.ChangePassword(username,model);

                return Ok("Password changed successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur during password change
                return BadRequest("An error occurred while changing the password.");
            }
        }

        [HttpGet("GetProfile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                var username = User.Identity.Name;
                return Ok(await _profileRepository.GetProfilePatient(username));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("GetProfileEmp")]
        [Authorize]
        public async Task<IActionResult> GetProfileEmp()
        {
            try
            {
                var username = User.Identity.Name;
                return Ok(await _profileRepository.GetProfileEmp(username));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("GetProfile/Update")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile(UpdatePatientModels model)
        {
            try
            {
                var username = User.Identity.Name;
                await _profileRepository.UpdateProfile(username, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("GetProfileEmp/Update")]
        [Authorize]
        public async Task<IActionResult> UpdateProfileEmp(UpdateEmpModels model)
        {
            try
            {
                var username = User.Identity.Name;
                await _profileRepository.UpdateProfileEmp(username, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("UploadImg")]
        [Authorize]
        public IActionResult UploadImage([FromForm] IFormFile image, [FromForm] string userType)
        {
            var username = User.Identity.Name;
            // Kiểm tra xem có file được gửi lên không
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

            // Cập nhật đường dẫn ảnh vào bảng tương ứng (Patient hoặc Employee)
            if (userType == "User")
            {
                var patient = _context.Patients.SingleOrDefault(u => u.Username == username);
                if (patient != null)
                {
                    patient.Img = fullPath;
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound("Patient not found");
                }
            }
            else if (userType == "Employee")
            {
                var employee = _context.Employees.SingleOrDefault(u => u.Username == username);
                if (employee != null)
                {
                    employee.Img = fullPath;
                    _context.Employees.Update(employee);
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound("Employee not found");
                }
            }
            else
            {
                return BadRequest("Invalid userType");
            }

            return Ok(new { imagePath = fullPath });
        }

    }
}

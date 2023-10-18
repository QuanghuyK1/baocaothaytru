using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using WEB_TTTN.Entities;
using WEB_TTTN.Helpers;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;
using WEB_TTTN.Repositories;
using static QRCoder.PayloadGenerator;

namespace WEB_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly HospitalDatabaseContext _context;
        private readonly IScheduleRepository _ischeduleRepository;
        private readonly EmailService _emailService;
        private readonly IMapper _mapper;
        public ScheduleController(HospitalDatabaseContext context, EmailService emailService,IScheduleRepository repo, IMapper mapper)
        {
            _ischeduleRepository = repo;
            _context = context;
            _emailService = emailService;
            _mapper = mapper;

        }
        [HttpPost("RegisSchedule")]
        
        public async Task<IActionResult> InsertSchedule(InputSchedule model)
        {
            try
            {
                if (model.Eventname == null)
                {
                    return BadRequest(validate.ProcessString("validate_blank"));
                }
                if (model.Description == null)
                {
                    return BadRequest(validate.ProcessString("validate_blank"));
                }
                if (model.Name == null)
                {
                    return BadRequest(validate.ProcessString("validate_blank"));
                }
                if (model.PhoneNumber == null)
                {
                    return BadRequest(validate.ProcessString("validate_blank"));
                }
                if (model.Email == null)
                {
                    return BadRequest(validate.ProcessString("validate_blank"));
                }
                string pattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
                if (Regex.IsMatch(model.Email, pattern))
                {
                    return BadRequest(validate.ProcessString("validate_email_err"));
                }
                var username = model.Username;
                await _ischeduleRepository.InsertSchedule(model, username);
                return Ok("success");
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("GetSchedule/{id}")]
        [Authorize]
        public async Task<IActionResult> getSchedule([FromRoute] int id)
        {
            try
            {
                var username = User.Identity.Name;
                
                return Ok(await _ischeduleRepository.GetscheduleId(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("GetScheduleByFill")]
        [Authorize]
        public async Task<IActionResult> GetScheduleByFill([FromForm] string eventname, [FromForm] DateTime date, [FromForm] string name, [FromForm] string phone)
        {
            try
            {
                var query = _context.Schedules.AsQueryable();

                if (!string.IsNullOrEmpty(eventname))
                {
                    query = query.Where(s => s.Eventname.Contains(eventname));
                }

                if (date != default(DateTime))
                {
                    query = query.Where(s => s.Starttime == date);
                }

                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(s => s.Name.Contains(name));
                }

                if (!string.IsNullOrEmpty(phone))
                {
                    query = query.Where(s => s.PhoneNumber.Contains(phone));
                }

                // Thực hiện truy vấn và trả về kết quả
                var result = await query.ToListAsync();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("SearchSchedule")]
        [Authorize]
        public async Task<IActionResult> Search([FromForm] DateTime date, [FromForm] string name, [FromForm] string phone)
        {
            try
            {
                var schedule = await _context.Schedules
                .Where(s => s.Name == name && s.PhoneNumber == phone && s.Starttime == date && s.Status == 0)
                .FirstOrDefaultAsync();
                return Ok(schedule);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("ActiveSchedule")]
        [Authorize]
        public async Task<IActionResult> Active([FromForm] int id)
        {
            try
            {
                var schedule = await _context.Schedules.SingleOrDefaultAsync(u => u.Id == id);
                schedule.Status = 1;
                return Ok(schedule);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> getall()
        {
            try
            {
                var schedule = await _context.Schedules.ToListAsync();
                foreach(var s in schedule)
                {
                    if (s.Starttime < DateTime.Now) // Kiểm tra nếu starttime đã quá hạn
                    {
                        s.Status = 2; // Chuyển status thành 3
                    }
                }
                return Ok(schedule);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("GetAllPatSchedule")]
        [Authorize]
        public async Task<IActionResult> GetAllPatSchedule()
        {
            try
            {
                var schedules = await _ischeduleRepository.GetAllPatSchedule();
                var scheduleModels = _mapper.Map<List<ScheduleModels>>(schedules);
                return Ok(scheduleModels);
            }
            catch
            {
                return BadRequest("Failed to retrieve patient schedules.");
            }
        }

        [HttpGet("GetAllEmpSchedule")]
        [Authorize]
        public async Task<IActionResult> GetAllEmpSchedule()
        {
            try
            {
                var username = User.Identity.Name;
                var schedules = await _ischeduleRepository.GetAllEmpSchedule(username);
                var scheduleModels = _mapper.Map<List<ScheduleModels>>(schedules);
                return Ok(scheduleModels);
            }
            catch
            {
                return BadRequest("Failed to retrieve employee schedules.");
            }
        }
        [HttpGet("GetAllEmpScheduleByAdmin")]
        [Authorize]
        public async Task<IActionResult> GetAllEmp()
        {
            try
            {
                var username = User.Identity.Name;
                var schedules = await _ischeduleRepository.GetAllEmp(username);
                var scheduleModels = _mapper.Map<List<ScheduleModels>>(schedules);
                return Ok(scheduleModels);
            }
            catch
            {
                return BadRequest("Failed to retrieve employee schedules.");
            }
        }
        [HttpPost("InsertScheduleEmp")]
        [Authorize]
        public async Task<IActionResult> InsertScheduleEmp([FromBody] InputScheduleEmp model)
        {
            try
            {
                var username = User.Identity.Name; // Lấy tên người dùng từ ngữ cảnh đăng nhập
                await _ischeduleRepository.InsertScheduleEmp(model, username);
                return Ok("Employee schedule inserted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to insert employee schedule.");
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_TTTN.Entities;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;

namespace WEB_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminEmpController : ControllerBase
    {
        private readonly IAdminEmpRepository _adminEmpRepository;
        private readonly HospitalDatabaseContext _dbcontext;
        public AdminEmpController(IAdminEmpRepository adminEmpRepository, HospitalDatabaseContext dbcontext)
        {
            _adminEmpRepository = adminEmpRepository;
            _dbcontext = dbcontext;
        }

        [HttpGet("GetListEmp")]
        public async Task<IActionResult> GetListEmp()
        {
            try
            {
                var empList = await _adminEmpRepository.GetListEmp();
                return Ok(empList);
            }
            catch
            {
                return BadRequest("Failed to retrieve employee list.");
            }
        }
        [HttpGet("GetRolename")]
        public async Task<IActionResult> GetRolename()
        {
            try
            {
                var empList = await _dbcontext.EmployeeRoles.ToListAsync();
                return Ok(empList);
            }
            catch
            {
                return BadRequest("Failed to retrieve employee list.");
            }
        }
        [HttpGet("GetRole")]
        public async Task<IActionResult> GetRole()
        {
            try
            {
                var empList = await _dbcontext.Roles.ToListAsync();
                return Ok(empList);
            }
            catch
            {
                return BadRequest("Failed to retrieve employee list.");
            }
        }
        [HttpPut("UpdateEmp/{username}")]
        [Authorize]
        public async Task<IActionResult> UpdateEmp([FromBody] InputEmp emp, [FromRoute] string username)
        {
            try
            {
                await _adminEmpRepository.UpdateEmp(emp, username);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteEmp/{username}")]
        [Authorize]
        public async Task<IActionResult> DeleteEmp([FromRoute] string username)
        {
            try
            {
                await _adminEmpRepository.DeleteEmp(username);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("InsertEmp")]
        [Authorize]
        public async Task<IActionResult> InsertEmp([FromBody] InsertEmpModel emp)
        {
            try
            {
                await _adminEmpRepository.InsertEmp(emp);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

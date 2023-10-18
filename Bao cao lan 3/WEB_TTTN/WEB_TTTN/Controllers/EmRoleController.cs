using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Models;
using WEB_TTTN.Repositories;

namespace WEB_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmRoleController : ControllerBase
    {
        private readonly IEmployeeRoleRepository _employeeRoleRepository;
        public EmRoleController(IEmployeeRoleRepository repo)
        {
            _employeeRoleRepository = repo;

        }
        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAllNation()
        {
            try
            {
                return Ok(await _employeeRoleRepository.ListRole());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("InsEmRole")]
        [Authorize]
        public async Task<IActionResult> InsEmrole(EmployeeRoleModels model)
        {
            try
            {
                await _employeeRoleRepository.InsertEmployeeRole(model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("UpEmRole/{id}")]
        [Authorize]
        public async Task<IActionResult> UpEmrole(EmployeeRoleModels model, [FromRoute] int id)
        {
            try
            {
                await _employeeRoleRepository.UpdateEmployeeRole(model, id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

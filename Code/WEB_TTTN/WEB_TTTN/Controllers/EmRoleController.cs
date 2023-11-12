using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Helpers;
using WEB_TTTN.Models;
using WEB_TTTN.Repositories;

namespace WEB_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmRoleController : ControllerBase
    {
        private readonly IEmployeeRoleRepository _employeeRoleRepository;
        private readonly validate _validate;
        public EmRoleController(IEmployeeRoleRepository repo, validate validate)
        {
            _employeeRoleRepository = repo;
            _validate = validate;

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
                if(model.RoleName == null)
                {
                    return BadRequest(validate.ProcessString("validate_blank"));
                }
                await _employeeRoleRepository.InsertEmployeeRole(model);
                return Ok(validate.ProcessString("Success_1"));
            }
            catch
            {
                return BadRequest(validate.ProcessString("Fail_1"));
            }
        }
        [HttpPost("UpEmRole/{id}")]
        [Authorize]
        public async Task<IActionResult> UpEmrole(EmployeeRoleModels model, [FromRoute] int id)
        {
            try
            {
                if (model.RoleName == null)
                {
                    return BadRequest(validate.ProcessString("validate_blank"));
                }
                await _employeeRoleRepository.UpdateEmployeeRole(model, id);
                return Ok(validate.ProcessString("Success_2"));
            }
            catch
            {
                return BadRequest(validate.ProcessString("Fail_2"));
            }
        }
    }
}

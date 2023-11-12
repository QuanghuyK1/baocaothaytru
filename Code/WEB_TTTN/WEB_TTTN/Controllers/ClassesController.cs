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
    public class ClassesController : ControllerBase
    {
        private readonly IClassesReposiroty _IclassesRepository;

        public ClassesController(IClassesReposiroty iclassesRepository)
        {
            _IclassesRepository = iclassesRepository;
        }

        [HttpPost("InsertClasses")]
        [Authorize]
        public async Task<IActionResult> InsertClasses([FromBody] ClassesModel model)
        {
            try
            {
                if(model.ClassName == null)
                {
                    return BadRequest(validate.ProcessString("validate_blank"));
                }
                await _IclassesRepository.insertClasses(model);
                return Ok(validate.ProcessString("Success_1"));
            }
            catch
            {
                return BadRequest(validate.ProcessString("Fail_1"));
            }
        }

        [HttpPost("UpdateClasses/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateClasses([FromBody] ClassesModel model, [FromRoute] int id)
        {
            try
            {
                if (model.ClassName == null)
                {
                    return BadRequest(validate.ProcessString("validate_blank"));
                }
                await _IclassesRepository.updateClasses(model, id);
                return Ok(validate.ProcessString("Success_2"));
            }
            catch
            {
                return BadRequest(validate.ProcessString("Fail_2"));
            }
        }

        [HttpGet("GetAllClasses")]
        [Authorize]
        public async Task<IActionResult> GetAllClasses()
        {
            try
            {
                var classes = await _IclassesRepository.getall();
                return Ok(classes);
            }
            catch
            {
                return BadRequest("Failed to retrieve Classes.");
            }
        }
    }
}

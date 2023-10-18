using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                await _IclassesRepository.insertClasses(model);
                return Ok("Class inserted successfully.");
            }
            catch
            {
                return BadRequest("Failed to insert Class.");
            }
        }

        [HttpPost("UpdateClasses/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateClasses([FromBody] ClassesModel model, [FromRoute] int id)
        {
            try
            {
                await _IclassesRepository.updateClasses(model, id);
                return Ok("Class updated successfully.");
            }
            catch
            {
                return BadRequest("Failed to update Class.");
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

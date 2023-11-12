using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Models;
using WEB_TTTN.Repositories;

namespace WEB_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeServiceController : ControllerBase
    {
        private readonly ITypeServiceRepository _typeServiceRepository;

        public TypeServiceController(ITypeServiceRepository typeServiceRepository)
        {
            _typeServiceRepository = typeServiceRepository;
        }

        [HttpPost("DelTypeService/{id}")]
        [Authorize]
        public async Task<IActionResult> DelTypeService([FromRoute] int id)
        {
            try
            {
                await _typeServiceRepository.DelTypeService(id);
                return Ok("TypeService deleted successfully.");
            }
            catch
            {
                return BadRequest("Failed to delete TypeService.");
            }
        }

        [HttpPost("InsertTypeService")]
        [Authorize]
        public async Task<IActionResult> InsertTypeService([FromBody] TypeServiceModels model)
        {
            try
            {
                await _typeServiceRepository.InsertTypeService(model);
                return Ok("TypeService inserted successfully.");
            }
            catch
            {
                return BadRequest("Failed to insert TypeService.");
            }
        }

        [HttpGet("ListTypeServices")]
        [Authorize]
        public async Task<IActionResult> ListTypeServices()
        {
            try
            {
                var typeServices = await _typeServiceRepository.list();
                return Ok(typeServices);
            }
            catch
            {
                return BadRequest("Failed to retrieve TypeServices.");
            }
        }

        [HttpPost("UpdateTypeService/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateTypeService([FromBody] TypeServiceModels model, [FromRoute] int id)
        {
            try
            {
                await _typeServiceRepository.UpdateTypeService(model, id);
                return Ok("TypeService updated successfully.");
            }
            catch
            {
                return BadRequest("Failed to update TypeService.");
            }
        }
    }
}

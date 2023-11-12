using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Helpers;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;
using WEB_TTTN.Repositories;

namespace WEB_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly validate validate;
        public LocationController(ILocationRepository repo)
        {
            _locationRepository = repo;

        }
        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAllLocation()
        {
            try
            {
                var list = await _locationRepository.GetListLocation();
                return Ok(list);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("InsLocation")]
        [Authorize]
        public async Task<IActionResult> InsNation(InputLocation location)
        {
            try
            {
                if(location.Name == null || location.Description == null || location.Img==null)
                {
                    return BadRequest(validate.ProcessString("validate_blank"));
                }
                await _locationRepository.InsertLocation(location);
                return Ok(validate.ProcessString("Success_1"));
            }
            catch
            {
                return BadRequest(validate.ProcessString("Fail_1"));
            }
        }
        [HttpPost("UpLocation/{id}")]
        [Authorize]
        public async Task<IActionResult> UpNation(InputLocation location, [FromRoute] int id)
        {
            try
            {
                if (location.Name == null || location.Description == null || location.Img == null)
                {
                    return BadRequest(validate.ProcessString("validate_blank"));
                }
                await _locationRepository.UpdateLocation(location, id);
                return Ok(validate.ProcessString("Success_1"));
            }
            catch
            {
                return BadRequest(validate.ProcessString("Fail_1"));
            }
        }
    }
}

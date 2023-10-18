using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                await _locationRepository.InsertLocation(location);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("UpLocation/{id}")]
        [Authorize]
        public async Task<IActionResult> UpNation(InputLocation location, [FromRoute] int id)
        {
            try
            {
                await _locationRepository.UpdateLocation(location, id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

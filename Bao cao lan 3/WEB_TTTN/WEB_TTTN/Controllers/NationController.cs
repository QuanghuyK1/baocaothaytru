using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Entities;
using WEB_TTTN.Models;
using WEB_TTTN.Repositories;

namespace WEB_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationController : ControllerBase
    {
        private readonly INationRepository _inationRepository;
        public NationController(INationRepository repo)
        {
            _inationRepository = repo;

        }
        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAllNation() {
            try
            {
                return Ok(await _inationRepository.GetAllNations());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("InsNation")]
        [Authorize]
        public async Task<IActionResult> InsNation(NationModels nation)
        {
            try
            {
                await _inationRepository.InsertNation(nation);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("UpNation/{id}")]
        [Authorize]
        public async Task<IActionResult> UpNation(NationModels nation, [FromRoute] int id)
        {
            try
            {
                await _inationRepository.UpdateNation(nation,id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

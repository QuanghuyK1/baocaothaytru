using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Entities;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;
using WEB_TTTN.Repositories;

namespace WEB_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineBillController : ControllerBase
    {
        private readonly IMedicineBillRepository _medicineBillRepository;
        private readonly HospitalDatabaseContext _hospitalDatabaseContext;

        public MedicineBillController(IMedicineBillRepository medicineBillRepository, HospitalDatabaseContext hospitalDatabaseContext)
        {
            _medicineBillRepository = medicineBillRepository;
            _hospitalDatabaseContext = hospitalDatabaseContext;
        }

        [HttpPost("InsertBill")]
        [Authorize]
        public async Task<IActionResult> InsertBill([FromBody] InputMedicineBill input)
        {
            try
            {
               
                await _medicineBillRepository.InsertBill(input);
                return Ok("MedicineBill inserted successfully.");
            }
            catch
            {
                return BadRequest("Failed to insert MedicineBill.");
            }
        }

        [HttpPost("UpdateBill/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateBill([FromBody] InputMedicineBill input, [FromRoute] int id)
        {
            try
            {
               
                await _medicineBillRepository.UpdateBill(input, id);
                return Ok("MedicineBill updated successfully.");
            }
            catch
            {
                return BadRequest("Failed to update MedicineBill.");
            }
        }

        [HttpPost("DeleteBill/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBill([FromRoute] int id)
        {
            try
            {
                await _medicineBillRepository.DeleteMedicineBill(id);
                return Ok("MedicineBill deleted successfully.");
            }
            catch
            {
                return BadRequest("Failed to delete MedicineBill.");
            }
        }

        [HttpGet("GetAllByService/{id}")]
        [Authorize]
        public async Task<IActionResult> GetAllByService([FromRoute] int id)
        {
            try
            {
                var medicineBills = await _medicineBillRepository.GetAllByService(id);
                return Ok(medicineBills);
            }
            catch
            {
                return BadRequest("Failed to retrieve MedicineBills.");
            }
        }

        [HttpPost("AcceptBill")]
        [Authorize]
        public async Task<IActionResult> AcceptBill([FromBody] List<MedicineBillModels> list)
        {
            try
            {
                await _medicineBillRepository.AcceptBill(list);
                return Ok("MedicineBills accepted successfully.");
            }
            catch
            {
                return BadRequest("Failed to accept MedicineBills.");
            }
        }
        [HttpGet("Get/{id}")]
        [Authorize]
        public async Task<IActionResult> GetService([FromRoute] int id)
        {
            try
            {
                var service = await _medicineBillRepository.FindMedBill(id);
                if (service == null)
                {
                    return NotFound($"Service with ID {id} not found");
                }
                return Ok(service);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching service.");
            }
        }
    }
}

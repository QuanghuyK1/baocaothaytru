using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Entities;
using WEB_TTTN.Helpers;
using WEB_TTTN.Models;
using WEB_TTTN.Repositories;
using WEB_TTTN.InputBody;
using System.Text.RegularExpressions;

namespace WEB_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineBillController : ControllerBase
    {
        private readonly IMedicineBillRepository _medicineBillRepository;
        private readonly HospitalDatabaseContext _hospitalDatabaseContext;
        private readonly validate validate;

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
               if(input.Count == 0)
                {
                    return BadRequest(validate.ProcessString("validate_blank"));
                }
                
                await _medicineBillRepository.InsertBill(input);
                return Ok(validate.ProcessString("Success_1"));
            }
            catch
            {
                return BadRequest(validate.ProcessString("Fail_1"));
            }
        }

        [HttpPost("UpdateBill/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateBill([FromBody] InputMedicineBill input, [FromRoute] int id)
        {
            try
            {
                if (input.ServiceId == null || input.MedName == null  || input.Price == 0 || input.TotalPrice == 0 || input.Count == 0)
                {
                    return BadRequest(validate.ProcessString("validate_blank"));
                }
                await _medicineBillRepository.UpdateBill(input, id);
                return Ok(validate.ProcessString("Success_2"));
            }
            catch
            {
                return BadRequest(validate.ProcessString("Fail_2"));
            }
        }

        [HttpPost("DeleteBill/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBill([FromRoute] int id)
        {
            try
            {
                await _medicineBillRepository.DeleteMedicineBill(id);
                return Ok(validate.ProcessString("Success_2"));
            }
            catch
            {
                return BadRequest(validate.ProcessString("Fail_3"));
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
                return Ok(validate.ProcessString("Success_4"));
            }
            catch
            {
                return BadRequest(validate.ProcessString("Fail_4"));
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
        [HttpPost("AcceptBillByCode")]
        [Authorize]
        public async Task<IActionResult> AcceptBillByCode([FromBody] List<MedicineBillModels> list)
        {
            try
            {
                await _medicineBillRepository.AcceptBillBycode(list);
                return Ok(validate.ProcessString("Success_4"));
            }
            catch
            {
                return BadRequest(validate.ProcessString("Fail_4"));
            }
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;
using WEB_TTTN.Repositories;

namespace WEB_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientController(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        [HttpGet("All")]
        [Authorize]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientRepository.GetAll();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetPatientById([FromRoute]int id)
        {
            var patient = await _patientRepository.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpGet("{patientId}/Schedules")]
        [Authorize]
        public async Task<IActionResult> GetSchedulesByPatient(int patientId)
        {
            var schedules = await _patientRepository.GetAllSchedulesByPatient(patientId);
            return Ok(schedules);
        }

        [HttpGet("{patientId}/Services")]
        [Authorize]
        public async Task<IActionResult> GetServicesByPatient(int patientId)
        {
            var services = await _patientRepository.GetAllServiceByPatient(patientId);
            return Ok(services);
        }

        [HttpPost("Ins")]
        [Authorize]
        public async Task<IActionResult> InsertPatient([FromBody] InputPatient input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var patientModel = new PatientModels
                {
                    Name = input.Name,
                    PhoneNumber = input.PhoneNumber,
                    Address = input.Address
                };
                await _patientRepository.InsertPatient(patientModel);
                return Ok("Patient inserted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPost("Update/{id}")]
        [Authorize]
        public async Task<IActionResult> UpsPatient([FromBody] InputPatient input, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var patientModel = new PatientModels
                {
                    InsuranceId = input.InsuranceId,
                    Name = input.Name,
                    PhoneNumber = input.PhoneNumber,
                    Address = input.Address,
                    Email = input.Email,
                };
                await _patientRepository.UpdatePatient(patientModel,id);
                return Ok("Patient inserted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("Search")]
        [Authorize]
        public async Task<IActionResult> SearchPatients([FromQuery] string name, [FromQuery] string phonenumber)
        {

            var searchedPatients = await _patientRepository.SearchPatient(name, phonenumber);
            return Ok(searchedPatients);
        }
    }
}

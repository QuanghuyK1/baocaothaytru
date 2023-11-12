using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using WEB_TTTN.Helpers;
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
                return BadRequest(validate.ProcessString("Not_found"));
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
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if ( input.Name.Length == 0 || input.PhoneNumber.Length == 0 || input.Address.Length == 0)
                {
                    return BadRequest(validate.ProcessString("validate_blank"));
                }
                else if(input.PhoneNumber.Length > 10 || int.TryParse(input.PhoneNumber, out int val) == false)
                {
                    return BadRequest(validate.ProcessString("Fail_13"));
                }else
                {
                    var patientModel = new PatientModels
                    {
                        Name = input.Name,
                        PhoneNumber = input.PhoneNumber,
                        Address = input.Address
                    };
                    await _patientRepository.InsertPatient(patientModel);
                    return Ok(validate.ProcessString("Success_1"));
                }
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
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (input.Email.Length == 0 || input.Name.Length == 0 || input.PhoneNumber.Length == 0 || input.Address.Length == 0)
                {
                    return BadRequest(validate.ProcessString("validate_blank"));
                }
                else
                {
                    string pattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
                    if (Regex.IsMatch(input.Email, pattern) == false)
                    {
                        return BadRequest(validate.ProcessString("validate_email_err"));
                    }
                    if (input.PhoneNumber.Length > 10 || int.TryParse(input.PhoneNumber, out int val) == false)
                    {
                        return BadRequest(validate.ProcessString("Fail_13"));
                    }
                    var patientModel = new PatientModels
                    {
                        InsuranceId = input.InsuranceId,
                        Name = input.Name,
                        PhoneNumber = input.PhoneNumber,
                        Address = input.Address,
                        Email = input.Email,
                    };
                    await _patientRepository.UpdatePatient(patientModel, id);
                    return Ok(validate.ProcessString("Success_2"));
                }
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

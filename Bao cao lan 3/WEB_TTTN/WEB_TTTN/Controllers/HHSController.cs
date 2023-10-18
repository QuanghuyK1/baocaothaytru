using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_TTTN.Entities;
using WEB_TTTN.Helpers;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;
using WEB_TTTN.Repositories;

namespace WEB_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HHSController : ControllerBase
    {
        private readonly HospitalDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly EmailService _emailService;
        private readonly IHHSRepository _hhsRepository;
        private readonly AutoIncre _autoIncre;
        private readonly IMapper _mapper;
        public HHSController(HospitalDatabaseContext context, IConfiguration configuration, EmailService emailService, IHHSRepository hHSRepository, AutoIncre autoIncre, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _emailService = emailService;
            _hhsRepository = hHSRepository;
            _autoIncre = autoIncre;
            _mapper = mapper;
        }

        [HttpPost("InsertHHS")]
        [Authorize]
        public async Task<IActionResult> InsertHHS(HospitalHealthInsuranceModels model)
        {
            try
            {
                var username = User.Identity.Name;
                await _hhsRepository.InsertHHSByPatient(model, username);
                return Ok("success");
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("GetHHS")]
        [Authorize]
        public async Task<IActionResult> GetHHS()
        {
            try
            {
                var username = User.Identity.Name;
                return Ok(await _hhsRepository.GetHHSByPatient(username));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("UploadImg")]
        [Authorize]
        public async Task<IActionResult> UpdateImgHhs([FromForm] IFormFile image)
        {
            try
            {
                var username = User.Identity.Name;
                await _hhsRepository.UploadImgHHS(image, username);
                return Ok("success");
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("PatientAskHHS")]
        [Authorize]
        public async Task<IActionResult> AskHHS(InputHHS input)
        {
            
            try
            {

                var username = User.Identity.Name;
                var nextId = await _autoIncre.GetNextIdAsync();
                Console.Write(username);
                var patient = await _context.Patients.SingleOrDefaultAsync(u => u.Username == username);
                if(patient != null)
                {
                    var model = new HospitalHealthInsuranceModels
                    {
                        InsuranceId = nextId,
                        HospitalName = "Hospital ABC",
                        Fee = -80,
                        FirstName = input.FirstName,
                        LastName = input.LastName,
                        Birthday = input.Birthday,
                        Createday = DateTime.Now,
                        Usedate = DateTime.Now.AddYears(3),
                        Startus = 0,
                        Img = null
                    };
                    var hhs = _mapper.Map<HospitalHealthInsurance>(model);
                    Console.Write(hhs.InsuranceId);
                    patient.InsuranceId = hhs.InsuranceId;
                    _context.HospitalHealthInsurances.Add(hhs);
                }
                else
                {
                    var model = new HospitalHealthInsuranceModels
                    {
                        InsuranceId = nextId,
                        HospitalName = "Hospital ABC",
                        Fee = -80,
                        FirstName = input.FirstName,
                        LastName = input.LastName,
                        Birthday = input.Birthday,
                        Createday = DateTime.Now,
                        Usedate = DateTime.Now.AddYears(3),
                        Startus = 0,
                        Img = null
                    };
                    var hhs = _mapper.Map<HospitalHealthInsurance>(model);
                    var patientmodel = new Patient
                    {
                        Name = input.FirstName + input.LastName,
                        InsuranceId = nextId,
                    };
                    _context.HospitalHealthInsurances.Add(hhs);
                    _context.Patients.Add(patientmodel);
                }
                await _context.SaveChangesAsync();
                
                return Ok("success");
            }
            catch
            {
                return BadRequest();
            }
        }
        // Assuming you have a DbContext named "YourDbContext" and an entity named "YourEntity" representing the table
        [HttpPost("Active/{id}")]
        [Authorize]
        public async Task<IActionResult> ActivateHealthInsurance([FromRoute] string id)
        {
            try
            {
                var hospitalInsurance = await _context.HospitalHealthInsurances.SingleOrDefaultAsync(u => u.InsuranceId == id);

                if (hospitalInsurance == null)
                {
                    return NotFound(); // Health insurance not found
                }

                hospitalInsurance.Startus = 1; // Assuming "Startus" is a typo and should be "Status"
                await _context.SaveChangesAsync();

                return Ok(); // Activation successful
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine("An error occurred: " + ex.ToString());
                return StatusCode(500); // Internal server error
            }
        }

        [HttpGet("GetAllHHS")]
        [Authorize]
        public async Task<IActionResult> getall()
        {

            try
            {
                return Ok(await _hhsRepository.GetAllHHS());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("GetHHS/{id}")]
        [Authorize]
        public async Task<IActionResult> getHHS([FromRoute] string id)
        {

            try
            {
                return Ok(await _hhsRepository.GetHHSById(id));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

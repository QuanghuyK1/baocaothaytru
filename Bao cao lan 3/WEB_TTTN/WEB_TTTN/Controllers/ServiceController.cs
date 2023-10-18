using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCode;
using SendGrid.Helpers.Mail;
using WEB_TTTN.Entities;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;
using WEB_TTTN.Repositories;

namespace WEB_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly HospitalDatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public ServiceController(IServiceRepository serviceRepository, HospitalDatabaseContext databaseContext, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        [HttpGet("Get/{id}")]
        [Authorize]
        public async Task<IActionResult> GetService([FromRoute] int id)
        {
            try
            {
                var service = await _serviceRepository.findService(id);
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

        [HttpPost("Ins")]
        [Authorize]
        public async Task<IActionResult> InsertService([FromBody] InputService input)
        {
            try
            {
                var username = User.Identity.Name;
                var emp = await _databaseContext.Employees.SingleOrDefaultAsync(u => u.Username == username);
                var type = await _databaseContext.TypeServices.SingleOrDefaultAsync(u => u.Id == input.TypeServiceId);
                var model = new ServiceModels
                {
                    PatientId = input.PatientId,
                    EmployeeId = emp.Id,
                    EmployeeName = emp.Name,
                    TypeServiceId = type.Id,
                    TypeServiceName = type.ServiceName,
                    EmpUsername = username,
                    Decription = input.Decription,
                    GetDate = input.GetDate,
                };
                await _serviceRepository.insertService(model);
                return Ok("Service inserted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while inserting service.");
            }
        }

        [HttpPost("Ups/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateService([FromRoute] int id, [FromBody] InputService input)
        {
            try
            {
                var username = User.Identity.Name;
                var emp = await _databaseContext.Employees.SingleOrDefaultAsync(u => u.Username == username);
                var type = await _databaseContext.TypeServices.SingleOrDefaultAsync(u => u.Id == input.TypeServiceId);
                var model = new ServiceModels
                {
                    PatientId = input.PatientId,
                    EmployeeId = emp.Id,
                    EmployeeName = emp.Name,
                    TypeServiceId = type.Id,
                    TypeServiceName = type.ServiceName,
                    EmpUsername = username,
                    Decription = input.Decription,
                    GetDate = input.GetDate,
                };
                await _serviceRepository.UpdateService(model, id);
                return Ok("Service updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating service.");
            }
        }
        [HttpPost("Search")]
        [Authorize]
        public async Task<IActionResult> Search([FromForm] DateTime date, [FromForm] int typeid)
        {
            try
            {
                var listmodel = await _databaseContext.Services.Where(u => u.GetDate.Date == date.Date && u.TypeServiceId == typeid).ToListAsync();
                List<ServiceModels> list = new List<ServiceModels>();
                foreach (var service in listmodel)
                {
                    ServiceModels model = _mapper.Map<ServiceModels>(service);
                    var typename = await _databaseContext.TypeServices.SingleOrDefaultAsync(s => s.Id == service.TypeServiceId);
                    var empname = await _databaseContext.Employees.SingleOrDefaultAsync(s => s.Id == service.EmployeeId);
                    model.TypeServiceName = typename.ServiceName;
                    model.EmployeeName = empname.Name;
                    model.EmpUsername = empname.Username;
                    list.Add(model);
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while inserting service.");

            }
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WEB_TTTN.Entities;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalDatabaseContext _context; // Thay IDbContext bằng interface cho DbContext của bạn
        private readonly IMapper _mapper;
        public PatientRepository(HospitalDatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PatientModels>> GetAll()
        {
            // Thực hiện lấy danh sách tất cả bệnh nhân từ context của bạn
            var patients = await _context.Patients.Where(u=>u.Username==null).ToListAsync();
            return _mapper.Map<List<PatientModels>>(patients);
        }

        public async Task<PatientModels> GetById(int id)
        {
            // Thực hiện lấy thông tin bệnh nhân theo ID từ context của bạn
            var patient = await _context.Patients.SingleOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<PatientModels>(patient);
        }

        public async Task<List<ScheduleModels>> GetAllSchedulesByPatient(int patientId)
        {
            // Thực hiện lấy danh sách tất cả lịch hẹn của bệnh nhân theo patientId từ context của bạn
            var schedules = await _context.Schedules.Where(s => s.Patientid == patientId).ToListAsync();
            return _mapper.Map< List<ScheduleModels>>(schedules);
        }

        public async Task<List<ServiceModels>> GetAllServiceByPatient(int patientId)
        {
            var services = await _context.Services.Where(s => s.PatientId == patientId).ToListAsync();
            List<ServiceModels> list = new List<ServiceModels>();
            foreach (Service service in services)
            {
                ServiceModels model = _mapper.Map<ServiceModels>(service);
                var typename = await _context.TypeServices.SingleOrDefaultAsync(s => s.Id == service.TypeServiceId);
                var empname = await _context.Employees.SingleOrDefaultAsync(s => s.Id == service.EmployeeId);
                model.TypeServiceName = typename.ServiceName;
                model.EmployeeName = empname.Name;
                model.EmpUsername = empname.Username;
                model.Decription = service.Decription;
                list.Add(model);
            }
            return list;
        }

        public async Task InsertPatient(PatientModels patient)
        {
            var newPatient = new Patient
            {
                Name = patient.Name,
                PhoneNumber = patient.PhoneNumber,
                Address = patient.Address,
                
            };
            _context.Patients.Add(newPatient);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PatientModels>> SearchPatient(string name, string phonenumber)
        {
            // Thực hiện lấy danh sách tất cả lịch hẹn của bệnh nhân theo patientId từ context của bạn
            var patient = await _context.Patients.Where(s => s.Name == name && s.PhoneNumber == phonenumber).ToListAsync();
            return _mapper.Map<List<PatientModels>>(patient);
        }

        public async Task UpdatePatient(PatientModels patient, int id)
        {
            var patiententity = await _context.Patients.SingleOrDefaultAsync(u => u.Id == id);
            patiententity.Name = patient.Name;
            patiententity.Email = patient.Email;
            patiententity.PhoneNumber = patient.PhoneNumber;
            patiententity.Address = patient.Address;
            patiententity.InsuranceId = patient.InsuranceId;
            await _context.SaveChangesAsync();
        }
    }
}

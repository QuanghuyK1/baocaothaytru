using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WEB_TTTN.Entities;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly HospitalDatabaseContext _context;
        private readonly IMapper _mapper;
        public ProfileRepository(HospitalDatabaseContext context, IMapper mapper) { 
            _context = context;
            _mapper = mapper;   
        }
        public async Task ChangePassword(string username, ChangePasswordModels account)
        {
            var existingPatient = await _context.Accounts.FirstOrDefaultAsync(p => p.Username == username);
            existingPatient.Password = BCrypt.Net.BCrypt.HashPassword(account.NewPass);
            await _context.SaveChangesAsync();
        }


        public async Task<List<ScheduleModels>> GetAllSchedules(String username)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Username == username);
            var schedules = await _context.Schedules.Where(e => e.Patientid == patient.Id).ToListAsync();
            return _mapper.Map<List<ScheduleModels>>(schedules);

        }

        public async Task<List<MedicineModels>> GetMedicineBill(ServiceModels service)
        {
            List<MedicineModels> listmedicine = new List<MedicineModels>();
            var List = await _context.MedicineBills!.Where(e => e.Serviceid == service.Id).ToListAsync();
            for(int i = 0; i < List.Count; i++)
            {
                var medicine = await _context.Medicines.SingleOrDefaultAsync(e => e.Id == List[i].Medicineid);
                var medicinemodel = _mapper.Map<MedicineModels>(medicine);
                var nationname = await _context.Nations.SingleOrDefaultAsync(e => e.Id == medicine.Nationid);
                medicinemodel.nationname = nationname.Name;
                listmedicine.Add(medicinemodel);
            }
            return listmedicine;
        }

        public async Task<PatientModels> GetProfilePatient(string username)
        {
            var patient = await _context.Patients.SingleOrDefaultAsync(e => e.Username == username);
            return _mapper.Map<PatientModels>(patient);
        }
        public async Task<EmpModels> GetProfileEmp(string username)
        {
            var emp = await _context.Employees.SingleOrDefaultAsync(e => e.Username == username);
            var empclass = _context.Classes.SingleOrDefault(e => e.Id == emp.ClassId);
            var emrole = _context.EmployeeRoles.SingleOrDefault(e => e.Id == emp.EmployeeRoleId);
            var model = new EmpModels();

            model = new EmpModels
            {
                Id = emp.Id,
                Name = emp.Name,
                Email = emp.Email,
                Birthday = emp.Birthday,
                Description = emp.Description,
                PhoneNumber = emp.PhoneNumber,
                Address = emp.Address,
                Classname = empclass.ClassName,
                EmployeeRoleName = emrole.RoleName,
                Identification = emp.Identification,
                Img = emp.Img,
                SalaryBasic = emp.SalaryBasic,
                Status = emp.Status

            };
            return model;
        }
        public Task RegisterScheduleCare(ScheduleModels model)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProfile(string username, UpdatePatientModels patient)
        {
            // Tìm kiếm bệnh nhân theo tên người dùng
            var existingPatient = await _context.Patients.FirstOrDefaultAsync(p => p.Username == username);

            // Nếu bệnh nhân không tồn tại, hiển thị thông báo lỗi hoặc xử lý theo yêu cầu của bạn
            if (existingPatient == null)
            {
                // Ví dụ:
                throw new Exception("Patient not found");
            }

            
            existingPatient.Name = patient.Name;
            existingPatient.Email = patient.Email;
            existingPatient.PhoneNumber = patient.PhoneNumber;
            existingPatient.Address = patient.Address;


            // Lưu thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

        }
        public async Task UpdateProfileEmp(string username, UpdateEmpModels emp)
        {
            // Tìm kiếm bệnh nhân theo tên người dùng
            var existingEmp = await _context.Employees.FirstOrDefaultAsync(p => p.Username == username);

            // Nếu bệnh nhân không tồn tại, hiển thị thông báo lỗi hoặc xử lý theo yêu cầu của bạn
            if (existingEmp == null)
            {
                // Ví dụ:
                throw new Exception("Emp not found");
            }


            existingEmp.Name = emp.Name;
            existingEmp.Email = emp.Email;
            existingEmp.PhoneNumber = emp.PhoneNumber;
            existingEmp.Address = emp.Address;
            existingEmp.Birthday = emp.Birthday;
            existingEmp.Identification = emp.Identification;
            existingEmp.Description = emp.Description;


            // Lưu thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

        }


    }
}

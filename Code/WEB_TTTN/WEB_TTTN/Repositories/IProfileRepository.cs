using WEB_TTTN.Entities;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public interface IProfileRepository
    {
        public Task<PatientModels> GetProfilePatient(string username);
        public Task<EmpModels> GetProfileEmp(string username);
        public Task ChangePassword(string username,ChangePasswordModels account);
        public Task UpdateProfile(string username, UpdatePatientModels model);
        public Task UpdateProfileEmp(string username, UpdateEmpModels model);
        public Task RegisterScheduleCare(ScheduleModels model);
        public Task<List<ScheduleModels>> GetAllSchedules(string username);
        public Task<List<MedicineModels>>   GetMedicineBill(ServiceModels service);
        
    }
}

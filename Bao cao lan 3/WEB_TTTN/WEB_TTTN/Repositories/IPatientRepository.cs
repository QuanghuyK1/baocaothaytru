using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public interface IPatientRepository
    {
        public Task<List<PatientModels>> GetAll();
        public Task<PatientModels> GetById(int id);
        public Task<List<ScheduleModels>> GetAllSchedulesByPatient(int patientid);

        public Task<List<ServiceModels>> GetAllServiceByPatient(int patientid);
        public Task InsertPatient(PatientModels patient);
        public Task UpdatePatient(PatientModels patient, int id);

        public Task<List<PatientModels>> SearchPatient(string name, string phonenumber);
    }
}

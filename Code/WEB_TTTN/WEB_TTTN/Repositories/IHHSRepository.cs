using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Helpers;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public interface IHHSRepository
    {
        public Task InsertHHSByPatient(HospitalHealthInsuranceModels model, string username);
       
        public Task<HospitalHealthInsuranceModels> GetHHSByPatient(string username);
        public Task ActiveHHSByEmployee(HospitalHealthInsuranceModels model, PatientModels patientModels);

        public Task UploadImgHHS([FromForm] IFormFile image, [FromForm] string username);
        public Task<List<HospitalHealthInsuranceModels>> GetAllHHS();
        public Task<HospitalHealthInsuranceModels> GetHHSById(string insuranceId);
    }
}

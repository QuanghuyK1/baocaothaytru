using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_TTTN.Entities;
using WEB_TTTN.Helpers;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public class HHSRepository : IHHSRepository
    {
        private readonly HospitalDatabaseContext _context;
        private readonly IMapper _mapper;
        public HHSRepository(HospitalDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task ActiveHHSByEmployee(HospitalHealthInsuranceModels model, PatientModels patientModels)
        {
            var patient = _mapper.Map<Patient>(patientModels);
            var hhs = await _context.HospitalHealthInsurances.SingleOrDefaultAsync(e => e.InsuranceId == patient.InsuranceId);

        }

        public async Task<List<HospitalHealthInsuranceModels>> GetAllHHS()
        {
            var list = await _context.HospitalHealthInsurances.ToListAsync();
            return _mapper.Map<List<HospitalHealthInsuranceModels>>(list);
        }

        public async Task<HospitalHealthInsuranceModels> GetHHSById(string insuranceId)
        {
            var hhs = await _context.HospitalHealthInsurances.SingleOrDefaultAsync(h => h.InsuranceId == insuranceId);
            var hhsmodel = _mapper.Map<HospitalHealthInsuranceModels>(hhs);
            return hhsmodel;
        }

        public async Task<HospitalHealthInsuranceModels> GetHHSByPatient(string username)
        {
            var patient = await _context.Patients.SingleOrDefaultAsync(u => u.Username == username);
            var hhs = await _context.HospitalHealthInsurances.SingleOrDefaultAsync(h => h.InsuranceId == patient.InsuranceId);
            var hhsmodel = _mapper.Map<HospitalHealthInsuranceModels>(hhs);
            return hhsmodel;
        }

        public async Task InsertHHSByPatient(HospitalHealthInsuranceModels model, string username)
        {
            var patient = await _context.Patients.SingleOrDefaultAsync(u => u.Username == username);
            if (patient.InsuranceId == null)
            {
                var hhs_exist = await _context.HospitalHealthInsurances.SingleOrDefaultAsync(u => u.InsuranceId == model.InsuranceId);
                var patient_exist = await _context.Patients.SingleOrDefaultAsync(u => u.InsuranceId == model.InsuranceId);
                if (hhs_exist!=null && patient_exist == null)
                {
                    patient.InsuranceId = model.InsuranceId;
                }
                else
                {
                    var hhs = _mapper.Map<HospitalHealthInsurance>(model);
                    _context.HospitalHealthInsurances.Add(hhs);
                    patient.InsuranceId = hhs.InsuranceId;
                }
            }
            else
            {
                var hhs = await _context.HospitalHealthInsurances.SingleOrDefaultAsync(u => u.InsuranceId == patient.InsuranceId);
                hhs.InsuranceId = model.InsuranceId;
                hhs.HospitalName = model.HospitalName;
                hhs.Usedate = model.Usedate;
                hhs.FirstName = model.FirstName;
                hhs.LastName = model.LastName;
                hhs.Createday = model.Createday;
                hhs.Birthday = model.Birthday;
                patient.InsuranceId = hhs.InsuranceId;
            }
             
            await _context.SaveChangesAsync();
        }


        public async Task UploadImgHHS([FromForm] IFormFile image, [FromForm] string username)
        {
            // Lưu ảnh vào thư mục trên server
            var imagePath = "D:\\TTTN\\WEB_TTTN\\WEB_TTTN\\ImagePath\\"; // Thay đổi đường dẫn tới thư mục lưu ảnh
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            var fullPath = Path.Combine(imagePath, uniqueFileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                image.CopyTo(stream);
            }
            var patient = await _context.Patients.SingleOrDefaultAsync(e => e.Username == username);
            var hhs = await _context.HospitalHealthInsurances.SingleOrDefaultAsync(u => u.InsuranceId == patient.InsuranceId);
            hhs.Img = fullPath;
            _context.SaveChangesAsync();
        }
    }
}

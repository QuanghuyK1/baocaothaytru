using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WEB_TTTN.Entities;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly HospitalDatabaseContext _context;
        private readonly IMapper _mapper;

        public CertificateRepository(HospitalDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task DeleteCertificate(int id)
        {
            var certificate = await _context.Certificates.SingleOrDefaultAsync(c => c.Id == id);
            _context.Certificates.Remove(certificate);
            await _context.SaveChangesAsync(); 
        }

        public async Task<List<CertificateModels>> GetAllCertificates(string username)
        {
            var emp = await _context.Employees.SingleOrDefaultAsync(e => e.Username == username);
            var list = await _context.Certificates.Where(c => c.PersonId == emp.Id).ToListAsync();
            return _mapper.Map<List<CertificateModels>>(list);
        }

        public async Task<CertificateModels> GetCertificates(int id)
        {
            var certificate = await _context.Certificates.SingleOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<CertificateModels>(certificate);
        }

        public async Task InsertCertificate(CertificateModels model, string username)
        {
            var emp = await _context.Employees.SingleOrDefaultAsync(e => e.Username == username);
            var certi = new Certificate
            {
                PersonId = emp.Id,
                CertificateName = model.CertificateName,
                Description = model.Description,
                Img = model.Img,
                Usedate = model.Usedate
            };
            
            _context.Certificates.Add(certi);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCertificate(CertificateModels model, int id)
        {
            var certificate = await _context.Certificates.SingleOrDefaultAsync(c => c.Id == id);
            certificate.CertificateName = model.CertificateName;
            certificate.Usedate = model.Usedate;
            certificate.Description = model.Description;
            certificate.Img = model.Img;
            await _context.SaveChangesAsync();
        }
    }
}

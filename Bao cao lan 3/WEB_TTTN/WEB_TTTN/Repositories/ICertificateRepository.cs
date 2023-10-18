using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public interface ICertificateRepository
    {
        public Task InsertCertificate(CertificateModels model, string username);
        public Task UpdateCertificate(CertificateModels model, int id);
        public Task<List<CertificateModels>> GetAllCertificates(string username);
        public Task<CertificateModels> GetCertificates(int id);

        public Task DeleteCertificate(int id);  
    }
}

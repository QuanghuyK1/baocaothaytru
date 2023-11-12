using WEB_TTTN.InputBody;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public interface IServiceRepository
    {
        public Task insertService(ServiceModels model);
        public Task<ServiceModels> findService(int id); 
        public Task UpdateService(ServiceModels model,int id);
        public Task<List<ServiceModels>> listService(int id);
    }
}

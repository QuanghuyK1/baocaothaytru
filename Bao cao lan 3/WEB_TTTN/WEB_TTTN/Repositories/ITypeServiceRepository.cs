using WEB_TTTN.Entities;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public interface ITypeServiceRepository
    {
        public Task InsertTypeService(TypeServiceModels model);
        public Task UpdateTypeService(TypeServiceModels model, int id);
        public Task DelTypeService(int id);
        public Task<List<TypeService>> list();
    }
}

using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public interface INationRepository
    {
        public Task InsertNation(NationModels model);
        public Task UpdateNation(NationModels model, int id);
        public Task<List<NationModels>> GetAllNations();
        public Task<NationModels> GetNationById(int id);

    }
}

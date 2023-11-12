using WEB_TTTN.Entities;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public interface ILocationRepository
    {
        public Task InsertLocation(InputLocation location);
        public Task UpdateLocation(InputLocation location, int id);
        public Task<List<LocationModals>> GetListLocation();
    }
}

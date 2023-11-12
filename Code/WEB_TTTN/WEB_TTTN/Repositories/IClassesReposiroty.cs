using WEB_TTTN.Entities;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public interface IClassesReposiroty
    {
        public Task insertClasses(ClassesModel model);
        public Task updateClasses(ClassesModel model, int id);
        public Task<List<ClassesModellist>> getall();
    }
}

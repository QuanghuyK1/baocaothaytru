using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public interface IEmployeeRoleRepository
    {
        public Task InsertEmployeeRole(EmployeeRoleModels model);
        public Task UpdateEmployeeRole(EmployeeRoleModels model,int id);
        public Task<List<EmployeeRoleModels>> ListRole();
    }
}

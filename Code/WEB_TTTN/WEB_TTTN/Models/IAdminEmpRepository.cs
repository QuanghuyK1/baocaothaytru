using WEB_TTTN.InputBody;

namespace WEB_TTTN.Models
{
    public interface IAdminEmpRepository
    {
        Task<List<EmpModels>> GetListEmp();
        Task UpdateEmp(InputEmp emp, string username);
        Task DeleteEmp(string username);
        Task InsertEmp(InsertEmpModel emp);
    }
}

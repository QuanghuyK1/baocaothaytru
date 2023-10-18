using WEB_TTTN.InputBody;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public interface IScheduleRepository
    {
        public Task InsertSchedule(InputSchedule model, string username);
        public Task<ScheduleModels> GetscheduleId(int id);
        public Task InsertScheduleEmp(InputScheduleEmp model, string username);
        public Task<List<ScheduleModels>> GetAllPatSchedule();
        public Task<List<ScheduleModels>> GetAllEmpSchedule(String username);
        public Task<List<ScheduleModels>> GetAllEmp(String username);
    }
}

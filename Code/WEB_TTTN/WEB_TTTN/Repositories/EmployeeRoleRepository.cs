using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WEB_TTTN.Entities;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public class EmployeeRoleRepository : IEmployeeRoleRepository
    {
        private readonly HospitalDatabaseContext _context;
        private readonly IMapper _mapper;
        public EmployeeRoleRepository(HospitalDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task InsertEmployeeRole(EmployeeRoleModels model)
        {
            var role = _mapper.Map<EmployeeRole>(model);
            _context.EmployeeRoles.Add(role);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EmployeeRoleModels>> ListRole()
        {
            var listrole = await _context.EmployeeRoles.ToListAsync();
            return _mapper.Map<List<EmployeeRoleModels>>(listrole);
        }

        public async Task UpdateEmployeeRole(EmployeeRoleModels model, int id)
        {
            var emrole = await _context.EmployeeRoles.FirstOrDefaultAsync(x => x.Id == id); 
            emrole.RoleName = model.RoleName;
            await _context.SaveChangesAsync();
        }
    }
}

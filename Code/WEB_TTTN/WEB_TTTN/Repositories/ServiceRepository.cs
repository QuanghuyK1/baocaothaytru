using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WEB_TTTN.Entities;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly HospitalDatabaseContext _context; // Thay IDbContext bằng interface cho DbContext của bạn
        private readonly IMapper _mapper;
        public ServiceRepository(HospitalDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceModels> findService(int id)
        {
            var entity = await _context.Services.FindAsync(id);
            var model = _mapper.Map<ServiceModels>(entity);
            var typename = await _context.TypeServices.SingleOrDefaultAsync(s => s.Id == entity.TypeServiceId);
            var empname = await _context.Employees.SingleOrDefaultAsync(s => s.Id == entity.EmployeeId);
            model.TypeServiceName = typename.ServiceName;
            model.EmployeeName = empname.Name;
            model.EmpUsername = empname.Username;
            return model;
        }

        public async Task insertService(ServiceModels model)
        {
            var service = new Service
            {
                PatientId = model.PatientId,
                EmployeeId = model.EmployeeId,
                TypeServiceId = model.TypeServiceId,
                Decription = model.Decription,
                GetDate = model.GetDate,
            };
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateService(ServiceModels model, int id)
        {
            var existingService = await _context.Services.SingleOrDefaultAsync(s => s.Id == id);
            if (existingService == null)
            {
                throw new Exception("Service not found");
            }
            existingService.Decription = model.Decription;
            await _context.SaveChangesAsync();
        }
        public async Task<List<ServiceModels>> listService(int id)
        {
            var services = await _context.Services.Where(s => s.PatientId == id).ToListAsync();
            List<ServiceModels> list = new List<ServiceModels>();
            foreach(Service service in services)
            {
                ServiceModels model = _mapper.Map<ServiceModels>(service);
                var typename = await _context.TypeServices.SingleOrDefaultAsync(s => s.Id == service.TypeServiceId);
                var empname = await _context.Employees.SingleOrDefaultAsync(s => s.Id == service.EmployeeId);
                model.TypeServiceName = typename.ServiceName;
                model.EmployeeName = empname.Name;
                model.EmpUsername = empname.Username;
                list.Add(model);
            }
            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WEB_TTTN.Entities;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public class TypeServiceRepository : ITypeServiceRepository
    {
        private readonly HospitalDatabaseContext _context;

        public TypeServiceRepository(HospitalDatabaseContext context)
        {
            _context = context;
        }

        public async Task DelTypeService(int id)
        {
            var typeService = await _context.TypeServices.FindAsync(id);
            if (typeService == null)
            {
                throw new Exception("TypeService not found");
            }

            typeService.Status = 0;
            await _context.SaveChangesAsync();
        }

        public async Task InsertTypeService(TypeServiceModels model)
        {
            var entity = new TypeService
            {
                ServiceName = model.ServiceName,
                Price = model.Price,
                Status = 1
            };

            _context.TypeServices.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TypeService>> list()
        {
            var typeServices = await _context.TypeServices.ToListAsync();
            
            return typeServices;
        }

        public async Task UpdateTypeService(TypeServiceModels model, int id)
        {
            var existingTypeService = await _context.TypeServices.SingleOrDefaultAsync(s => s.Id == id);
            if (existingTypeService == null)
            {
                throw new Exception("TypeService not found");
            }
            existingTypeService.ServiceName = model.ServiceName;
            existingTypeService.Price = model.Price;
                
            await _context.SaveChangesAsync();
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WEB_TTTN.Entities;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly HospitalDatabaseContext _context;
        private readonly IMapper _mapper;

        public MedicineRepository(HospitalDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task DeleteMedicine(int id)
        {
            var entity = await _context.Medicines.SingleOrDefaultAsync(u => u.Id == id);
            if (entity != null)
            {
                if(entity.Startus == 0)
                {
                    entity.Startus = 1;
                }
                else
                {
                    entity.Startus = 0;
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task<MedicineModels> GetMedicineById(int id)
        {
            var entity = await _context.Medicines.FindAsync(id);
            var nation = await _context.Nations.SingleOrDefaultAsync(u => u.Id == entity.Nationid);
            var model = _mapper.Map<MedicineModels>(entity);
            model.nationname = nation.Name;
            return model;
        }

        public async Task InsertMedicine(MedicineModels model)
        {
            var entity = _mapper.Map<Medicine>(model);
            var nation = await  _context.Nations.SingleOrDefaultAsync(u => u.Name == model.nationname);
            entity.Nationid = nation.Id;
            _context.Medicines.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MedicineModels>> ListMedicine()
        {
            var list = await _context.Medicines.ToListAsync();
            var listmodel = new List<MedicineModels>();
            foreach(Medicine m in list)
            {
                var nation = await _context.Nations.SingleOrDefaultAsync(u => u.Id == m.Nationid);
                var model = _mapper.Map<MedicineModels>(m);
                model.nationname = nation.Name;
                listmodel.Add(model);
            }
            return listmodel;
        }
        public async Task<List<MedicineModels>> ListMedicineStartus()
        {
            var list = await _context.Medicines.Where(u => u.Startus == 1).ToListAsync();
            var listmodel = new List<MedicineModels>();
            foreach (Medicine m in list)
            {
                var nation = await _context.Nations.SingleOrDefaultAsync(u => u.Id == m.Nationid);
                var model = _mapper.Map<MedicineModels>(m);
                model.nationname = nation.Name;
                listmodel.Add(model);
            }
            return listmodel;
        }
        public async Task UpdateMedicine(MedicineModels model, int id)
        {
            var entity = await _context.Medicines.SingleOrDefaultAsync(u => u.Id == id);
            var nation = await _context.Nations.SingleOrDefaultAsync(u => u.Name == model.nationname);
            if (entity != null)
            {
                // Update properties of the entity from the model
                entity.Name = model.Name;
                entity.Count = model.Count;
                entity.Img = model.Img;
                entity.Description = model.Description;
                entity.Nationid = nation.Id;
                entity.Price = model.Price;
                entity.HandlePrice = model.HandlePrice;
                entity.Usedate = model.Usedate;
                await _context.SaveChangesAsync();
            }
        }
    }
}

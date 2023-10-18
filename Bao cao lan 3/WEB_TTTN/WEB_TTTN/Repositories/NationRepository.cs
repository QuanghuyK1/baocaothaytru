using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WEB_TTTN.Entities;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public class NationRepository : INationRepository
    {
        private readonly HospitalDatabaseContext _context;
        private readonly IMapper _mapper;

        public NationRepository(HospitalDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<NationModels>> GetAllNations()
        {
            var listNation = await _context.Nations.ToListAsync();
            return _mapper.Map<List<NationModels>>(listNation);
        }

        public async Task<NationModels> GetNationById(int id)
        {
            var nation = await _context.Nations.SingleOrDefaultAsync(e => e.Id == id);
            return _mapper.Map<NationModels>(nation);
        }

        public async Task InsertNation(NationModels model)
        {
            var nation = _mapper.Map<Nation>(model);
            _context.Nations!.Add(nation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNation(NationModels model, int id)
        {
            var nation = await _context.Nations.SingleOrDefaultAsync(e => e.Id == id);
            nation.Name = model.Name;
            await _context.SaveChangesAsync();
        }
    }
}

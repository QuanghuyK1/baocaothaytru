using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WEB_TTTN.Entities;
using WEB_TTTN.InputBody;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly HospitalDatabaseContext _context;
        private readonly IMapper _mapper;
        public LocationRepository(HospitalDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task InsertLocation(InputLocation location)
        {
            var newLocation = new Location
            {
                Name = location.Name,
                Description = location.Description,
                Img = location.Img
            };

            _context.Locations.Add(newLocation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLocation(InputLocation location, int id)
        {
            var existingLocation = await _context.Locations.FindAsync(id);

            if (existingLocation != null)
            {
                existingLocation.Name = location.Name;
                existingLocation.Description = location.Description;
                existingLocation.Img = location.Img;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<LocationModals>> GetListLocation()
        {
            var locations = await _context.Locations.ToListAsync();
            return _mapper.Map<List<LocationModals>>(locations);
        }
    }
}

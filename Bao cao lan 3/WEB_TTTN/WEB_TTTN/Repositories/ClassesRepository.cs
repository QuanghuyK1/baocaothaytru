using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WEB_TTTN.Entities;
using WEB_TTTN.Models;

namespace WEB_TTTN.Repositories
{
    public class ClassesRepository : IClassesReposiroty
    {
        private readonly HospitalDatabaseContext _dbContext;
        private readonly IMapper _mapper;


        public ClassesRepository(HospitalDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task insertClasses(ClassesModel model)
        {
            var newClass = new Class
            {
                ClassName = model.ClassName,
                Img = model.Img,
            };

            _dbContext.Classes.Add(newClass);
            await _dbContext.SaveChangesAsync();
        }

        public async Task updateClasses(ClassesModel model, int id)
        {
            var existingClass = await _dbContext.Classes.FindAsync(id);

            if (existingClass != null)
            {
                existingClass.ClassName = model.ClassName;
                existingClass.Img = model.Img;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<ClassesModellist>> getall()
        {
            var list = await _dbContext.Classes.ToListAsync();
            return _mapper.Map<List<ClassesModellist>>(list);
        }
    }
}


using HNP.DATA.DI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HNP.DATA.DI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DataDbContext _context;
        public Repository(DataDbContext context)
        {
            _context = context;
        }
        public async Task Delete(string id)
        {
            T obj = await GetById(id);
            _context.Set<T>().Remove(obj);
            await SaveChange();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            
            var data= await _context.Set<T>().ToListAsync();
            return data;
        }

        public async Task<T> GetById(string id)
        {
           return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Post(T Tentity)
        {
           await _context.Set<T>().AddAsync(Tentity);
            await SaveChange();
        }

        public async Task Put(T obj)
        {
             _context.Set<T>().Update(obj);
            await SaveChange();
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }
    }
}

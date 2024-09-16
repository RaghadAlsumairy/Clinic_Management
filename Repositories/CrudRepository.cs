using ClinicManagementAPI.Data;
using ClinicManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementAPI.Repositories
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        private readonly ClinicDbContext _context;
        private readonly DbSet<T> _dbSet;

        public CrudRepository(ClinicDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        async Task ICrudRepository<T>.Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SecilStore.ApplicationCore.Entities;
using SecilStore.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecilStore.Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SecilStoreDbContext _dbContext;

        public EfRepository(SecilStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Configuration> FindByName(string name, string applicationName, bool isActive)
        {
            return await _dbContext.Configurations.FirstOrDefaultAsync(x => x.Name == name && x.ApplicationName == applicationName && x.IsActive == isActive);
        }

        public async Task<List<Configuration>> FindAllByApplicationName(string applicationName)
        {
            return await _dbContext.Configurations.Where(x => x.ApplicationName == applicationName).ToListAsync();
        }
    }
}

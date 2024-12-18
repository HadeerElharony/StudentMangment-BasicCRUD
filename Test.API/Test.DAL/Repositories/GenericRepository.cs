using Microsoft.EntityFrameworkCore;
using Test.DAL.DbContext;
using Test.DAL.Interfaces;
using Test.DAL.Models;

namespace Test.DAL.Repositories
{
    public class GenericRepository<T, Tx> : IGenericRepository<T, Tx> where T : class
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<T> _entity;
        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _entity = _dbContext.Set<T>();
        }
        public async Task<SaveDbResult> AddAsync(T entity)
        {
            await _entity.AddAsync(entity);
            return await SaveDatabaseChangesAsync();
        }

        public async Task<SaveDbResult> DeleteAsync(T entity)
        {
            _entity.Remove(entity);
            return await SaveDatabaseChangesAsync();
        }

        public Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate)
        {
            var result = _entity.AsNoTracking().Where(predicate);
            return Task.FromResult(result.AsEnumerable());
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _entity.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Tx id)
        {
            var entity = await _entity.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with ID {id} not found.");

            return entity;
        }

        public async Task<SaveDbResult> UpdateAsync(T entity)
        {
            _entity.Update(entity);
            return await SaveDatabaseChangesAsync();
        }

        protected async Task<SaveDbResult> SaveDatabaseChangesAsync()
        {
            var res = _dbContext.SaveChanges();

            return new SaveDbResult()
            {
                affectedRows = res
            };
        }
    }
}

using Test.DAL.Models;

namespace Test.DAL.Interfaces
{
    public interface IGenericRepository<T, Tx> where T : class
    {
        public Task<SaveDbResult> AddAsync(T entity);
        public Task<SaveDbResult> UpdateAsync(T entity);
        public Task<SaveDbResult> DeleteAsync(T entity);
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(Tx id);
        public Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate);
    }
}

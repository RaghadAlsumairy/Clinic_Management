using ClinicManagement.Models;

namespace ClinicManagementAPI.Repositories.Interfaces
{
    public interface ICrudRepository<T> where T : class
    {
        
        public Task<T> GetById(int id);
        public Task Add(T entity);
        public  Task UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
    }
}

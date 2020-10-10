using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taika.Repository
{
    public interface IGenericRepository<TData> where TData : class
    {
        Task<TData> GetByIdAsync(Guid id);
        Task<IEnumerable<TData>> GetAllAsync();
        Task<int> AddAsync(TData entity);
        Task<int> UpdateAsync(TData entity);
        Task<int> DeleteAsync(Guid id);
    }
}

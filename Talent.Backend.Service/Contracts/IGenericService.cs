using System.Collections.Generic;
using System.Threading.Tasks;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Contracts
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(PaginationDto paginationDto);
        Task<T> GetAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> ExistAsync(int id);
        Task<int> GetTotalRecorsdAsync();
    }
}

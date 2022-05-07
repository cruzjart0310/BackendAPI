using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Contracts
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(PaginationDto paginationDto);
        Task<T> GetAsync(string id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(T entity);
        Task<int> GetTotalRecorsdAsync();
    }
}

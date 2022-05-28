using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.DataAccessEF.Entities;
using Talent.Backend.DataAccessEF.Models;

namespace Talent.Backend.DataAccessEF.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Pagination pagination);
        Task<T> GetAsync(int id);
        Task <T> CreateAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
        Task<bool> ExistAsync(int id);
        Task<int> GetTotalRecorsdAsync();
    }
}

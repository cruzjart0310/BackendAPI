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
        Task<T> GetAsync(string id);
        Task <T> CreateAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(T entity);

        Task<int> GetTotalRecorsdAsync();
    }
}

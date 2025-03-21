using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AbstractRepository
{
    public interface IGenericRepository<T> where T : BaseClass
    {
        Task AddAsync(T entity);
        Task DeleteAsync(string id);
        Task UpdateAsync(T entity,string id);
        Task<T> GetByIdAsync(string id);
        Task<List<T>> GetAllAsync();
    }
}

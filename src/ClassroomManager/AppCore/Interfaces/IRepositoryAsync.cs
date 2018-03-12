using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Interfaces
{
    public interface IRepositoryAsync<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(long id);
        Task<T> GetByUserAsync(string user);
        Task<List<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
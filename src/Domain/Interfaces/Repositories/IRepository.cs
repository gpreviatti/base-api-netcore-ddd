using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> FindByIdAsync(Guid id);
        Task<IEnumerable<T>> FindAllAsync();
        Task<bool> ExistAsync(Guid id);
    }
}
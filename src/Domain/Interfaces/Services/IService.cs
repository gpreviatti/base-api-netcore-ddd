using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IService<T> where T : Entity
    {
        Task<T> FindById(Guid id);
        Task<IEnumerable<T>> FindAll();
        Task<T> Create(T user);
        Task<T> Update(T user);
        Task<bool> Delete(Guid id);
        Task<bool> ExistAsync(Guid id);
    }
}
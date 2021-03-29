using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<Entity>
    {
        Task<Entity> CreateAsync(Entity entity);
        Task<Entity> UpdateAsync(Entity entity);
        Task<bool> DeleteAsync(Guid id);
        Task<Entity> FindByIdAsync(Guid id);
        Task<IEnumerable<Entity>> FindAllAsync();
        Task<bool> ExistAsync(Guid id);
    }
}

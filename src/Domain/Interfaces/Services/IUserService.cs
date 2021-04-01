using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos.User;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IUserService : IBaseService
    {
        Task<User> FindByIdAsync(Guid id);
        Task<IEnumerable<User>> FindAllAsync();
        Task<User> CreateAsync(UserCreateDto entity);
        Task<User> UpdateAsync(User entity);
        Task<bool> DeleteAsync(Guid id);
    }
}

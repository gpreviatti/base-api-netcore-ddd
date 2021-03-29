using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Services
{
    public class UserService : BaseService, IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> FindByIdAsync(Guid id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<User>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<User> CreateAsync(User user)
        {
            return await _repository.CreateAsync(user);
        }

        public async Task<User> UpdateAsync(User user)
        {
            return await _repository.UpdateAsync(user);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}

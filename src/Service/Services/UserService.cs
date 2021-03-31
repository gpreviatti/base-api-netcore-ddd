using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using BC = BCrypt.Net.BCrypt;

namespace Service.Services
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
            try
            {
                return await _repository.FindByIdAsync(id);
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
                return new User();
            }
        }

        public async Task<IEnumerable<User>> FindAllAsync()
        {
            try
            {
                return await _repository.FindAllAsync();
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
                return new List<User>();
            }
        }

        public async Task<User> CreateAsync(User user)
        {
            try
            {
                // bool verified = BC.Verify("Pa$$w0rd", passwordHash);
                user.Password = BC.HashPassword(user.Password);
                return await _repository.CreateAsync(user);
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
                return new User();
            }
        }

        public async Task<User> UpdateAsync(User user)
        {
            try
            {
                return await _repository.UpdateAsync(user);
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
                return new User();
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                return await _repository.DeleteAsync(id);
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
                return false;
            }
        }
    }
}

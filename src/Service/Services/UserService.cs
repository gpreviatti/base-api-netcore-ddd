using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos.User;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Helpers;

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

        public async Task<User> CreateAsync(UserCreateDto userDto)
        {
            try
            {
                return await _repository
                .CreateAsync(new User()
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Password = EncryptHelper.HashField(userDto.Password),
                }
                );
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

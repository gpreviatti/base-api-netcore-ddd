using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dtos.User;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Helpers;

namespace Service.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserResultDto> FindByIdAsync(Guid id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                return _mapper.Map<UserResultDto>(result);
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
                return new UserResultDto();
            }
        }

        public async Task<IEnumerable<UserResultDto>> FindAllAsync()
        {
            try
            {
                var result = await _repository.FindAllAsync();
                return _mapper.Map<IEnumerable<UserResultDto>>(result);
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
                return new List<UserResultDto>();
            }
        }

        public async Task<UserResultDto> CreateAsync(UserCreateDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                user.Password = EncryptHelper.HashField(user.Password);

                var result = await _repository.CreateAsync(user);
                return _mapper.Map<UserResultDto>(user);
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
                return new UserResultDto();
            }
        }

        public async Task<UserResultDto> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            try
            {
                var user = _mapper.Map<User>(userUpdateDto);

                var updatedUser = await _repository.UpdateAsync(user);
                return _mapper.Map<UserResultDto>(updatedUser);
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
                return new UserResultDto();
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

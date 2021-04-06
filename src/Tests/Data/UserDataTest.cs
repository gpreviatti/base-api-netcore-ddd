using System;
using Data.Context;
using Data.Repositories;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests.Data
{
    public class UserDataTest : BaseDataTest
    {
        private readonly IUserRepository _repository;

        private User userTest;

        public UserDataTest()
        {
            _repository = new UserRepository(_context);

            userTest = new User()
            {
                Id = new Guid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                Password = "12345678",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }

        [Fact(DisplayName = "Create User")]
        [Trait("Data", "ShouldCreateUser")]
        public void ShouldCreateUser()
        {
            var result = _repository.CreateAsync(userTest).Result;

            Assert.NotNull(result);
            Assert.Equal(userTest.Email, result.Email);
            Assert.Equal(userTest.Name, result.Name);
            Assert.False(result.Id == Guid.Empty);
        }

        [Fact(DisplayName = "Update User")]
        [Trait("Data", "ShouldUpdateUser")]
        public void ShouldUpdateUser()
        {
            userTest.Name = Faker.Name.FullName();
            userTest.Email = Faker.Internet.Email();
            var result = _repository.SaveChangesAsync().Result;

            Assert.NotNull(result);
            Assert.Equal(1, result);
        }

        [Fact(DisplayName = "Delete User")]
        [Trait("Data", "ShouldDeleteUser")]
        public void ShouldDeleteUser()
        {
            var result = _repository.DeleteAsync(userTest.Id).Result;

            Assert.NotNull(result);
            Assert.Equal(true, result);
        }
    }
}

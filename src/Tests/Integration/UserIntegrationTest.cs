using System;
using System.Collections.Generic;
using System.Net;
using Domain.Dtos.User;
using Newtonsoft.Json;
using Xunit;

namespace Tests.Integration
{
    public class UserIntegrationTest : BaseIntegrationTest
    {
        public UserIntegrationTest()
        {
        }

        [Fact]
        [Trait("Integration", "ShouldListUser")]
        public async void ShouldListUser()
        {
            // Arrange

            // Assumption
            await AdicionarToken();
            var response = await GetAsync("users");
            var getResult = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<UserResultDto>>(getResult);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        [Trait("Integration", "ShouldCreateUser")]
        public async void ShouldCreateUser()
        {
            // Arrange
            var userCreateDto = new UserCreateDto()
            {
                Name = Faker.Name.First(),
                Email = Faker.Internet.Email(),
                Password = "mudar@123"
            };

            // Assumption
            await AdicionarToken();
            var response = await PostAsync(userCreateDto, "users");
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<UserResultDto>(postResult);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(userCreateDto.Name, registroPost.Name);
            Assert.Equal(userCreateDto.Email, registroPost.Email);
            Assert.True(registroPost.Id != default(Guid));
        }

        [Fact]
        [Trait("Integration", "ShouldUpdateUser")]
        public async void ShouldUpdateUser()
        {
            // Arrange
            var userUpdateDto = new UserUpdateDto()
            {
                Id = new Guid("6823c5ae-ca43-4287-82e1-10d5fca46a2e"),
                Name = Faker.Name.First()
            };

            // Assumption
            await AdicionarToken();
            var response = await PutAsync(userUpdateDto, "users");
            var putResult = await response.Content.ReadAsStringAsync();
            var updatedUser = JsonConvert.DeserializeObject<UserResultDto>(putResult);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(userUpdateDto.Name, updatedUser.Name);
            Assert.True(updatedUser.Id != default(Guid));
        }

        [Fact]
        [Trait("Integration", "ShouldDeleteUser")]
        public async void ShouldDeleteUser()
        {
            // Arrange
            var guid = "6823c5ae-ca43-4287-82e1-10d5fca46a2e";

            // Assumption
            await AdicionarToken();
            var response = await DeleteAsync("users/" + guid);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

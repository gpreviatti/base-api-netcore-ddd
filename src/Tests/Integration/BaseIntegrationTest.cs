using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Application;
using AutoMapper;
using CrossCutting.Mappings;
using Data.Context;
using Domain.Dtos;
using Domain.Dtos.Login;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Tests.Integration
{
    public abstract class BaseIntegrationTest
    {
        protected readonly IMapper _mapper;
        protected readonly HttpClient _client;
        private readonly string _hostApi;
        protected readonly MyContext _myContext;

        public BaseIntegrationTest()
        {
            _hostApi = "http://localhost:5000/";

            var builder = new WebHostBuilder()
               .UseEnvironment("Testing")
               .UseStartup<Startup>();

            var server = new TestServer(builder);

            _myContext = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            _myContext.Database.Migrate();

            _mapper = GetMapper();

            _client = server.CreateClient();
        }

        public async Task AdicionarToken()
        {
            var loginDto = new LoginDto()
            {
                Email = "admin@admin.com",
                Password = "mudar@123"
            };

            var resultLogin = await PostJsonAsync(loginDto, $"{_hostApi}login", _client);
            var jsonLogin = await resultLogin.Content.ReadAsStringAsync();
            var loginObject = JsonConvert.DeserializeObject<LoginResultDto>(jsonLogin);

            // Add default authorization in each request
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", 
                loginObject.AccessToken
            );
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object dataclass, string url, HttpClient client)
        {
            return await client.PostAsync(
                url,
                new StringContent(JsonConvert.SerializeObject(dataclass), Encoding.UTF8, "application/json")
            );
        }

        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            return config.CreateMapper();
        }
    }
}

using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Data
{
    public class BaseDataTest : IDisposable
    {
        private string dataBaseName = $"TestDb_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        protected readonly IServiceProvider _serviceProvider;
        protected readonly MyContext _context;

        public BaseDataTest()
        {
            var serviceCollection = new ServiceCollection();

            // In Memory
            // serviceCollection.AddDbContext<MyContext>(opt => opt.UseInMemoryDatabase(dataBaseName));

            // MySql
            // var connectionString = $"Server=localhost;Port=3306;Database={dataBaseName};Uid=application;Pwd=application";
            // serviceCollection.AddDbContext<MyContext>(
            //     options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            // );

            // SqlServer
            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer($"Server=DESKTOP-CJHGFFK;Database={dataBaseName};User Id=application;Password=application")
            );

            _serviceProvider = serviceCollection.BuildServiceProvider();
            _context = _serviceProvider.GetService<MyContext>();
            _context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}

using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Data
{
    public abstract class BaseDataTest
    {
        private string dataBaseName = $"TestDb_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        protected readonly IServiceProvider _serviceProvider;
        protected readonly MyContext _context;

        public BaseDataTest()
        {
            var serviceCollection = new ServiceCollection();

            // In Memory
            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Integrated Security=true;Initial Catalog=Microsoft.eShopOnWeb.Identity;")
            );

            _serviceProvider = serviceCollection.BuildServiceProvider();
            _context = _serviceProvider.GetService<MyContext>();
        }
    }
}

using Data.Context;
using Data.Repositories;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserRepository, UserRepository>();


            // MySql
            // var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=application;Pwd=application";
            // serviceCollection.AddDbContext<MyContext>(
            //     options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            // );

            // SqlServer
            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer("Server=DESKTOP-CJHGFFK;Database=BaseApi;User Id=application;Password=application")
            );
        }
    }
}

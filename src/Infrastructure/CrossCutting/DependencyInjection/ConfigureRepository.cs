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
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserRepository>();


            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=application;Pwd=application";
            serviceCollection.AddDbContext<MyContext>(
                options => options
                    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

            // serviceCollection.AddDbContext<MyContext>(
            //     options => options.UseSqlServer("Server=.\\SQLEXPRESS2017;Database=dbAPI;User Id=sa;Password=mudar@123")
            // );
        }
    }
}

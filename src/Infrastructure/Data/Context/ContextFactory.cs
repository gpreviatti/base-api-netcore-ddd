using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            // In Memory
            // optionsBuilder.UseInMemoryDatabase("Database");

            //MySql
            // var connectionString = "Server=localhost;Port=3306;Database=BaseApi;Uid=application;Pwd=application";
            // optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            //SQLServer
            var connectionString = "Server=DESKTOP-CJHGFFK;Database=BaseApi;User Id=application;Password=application";
            optionsBuilder.UseSqlServer(connectionString);

            return new MyContext(optionsBuilder.Options);
        }
    }
}

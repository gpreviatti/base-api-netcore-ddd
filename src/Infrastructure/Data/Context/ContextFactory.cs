using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            //MySql
            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=application;Pwd=application";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            //SQLServer
            // var connectionString = "Server=.\\SQLEXPRESS2017;Database=dbAPI;User Id=sa;Password=mudar@123";
            // optionsBuilder.UseSqlServer(connectionString);

            return new MyContext(optionsBuilder.Options);
        }
    }
}

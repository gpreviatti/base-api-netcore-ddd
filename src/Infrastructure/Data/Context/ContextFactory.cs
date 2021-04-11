using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            var dbConnection = Environment.GetEnvironmentVariable("DB_CONNECTION");

            //MySql
            // optionsBuilder.UseMySql(dbConnection, ServerVersion.AutoDetect(dbConnection));

            //SQLServer
            optionsBuilder.UseSqlServer(dbConnection);

            return new MyContext(optionsBuilder.Options);
        }
    }
}

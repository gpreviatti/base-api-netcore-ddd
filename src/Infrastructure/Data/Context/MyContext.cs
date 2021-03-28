using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            Database.Migrate();
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        // {
        //     //Usado para Criar as Migrações
        //     var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=application;Pwd=application";
        //     // var connectionString = "Server=.\\SQLEXPRESS2017;Database=dbAPI;User Id=sa;Password=mudar@123";

        //     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        //     // options.UseSqlServer(connectionString);
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(new UserMap().Configure);
        }
    }
}

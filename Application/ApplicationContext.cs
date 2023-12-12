using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Domain;

namespace Application
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User => Set<User>();
        public DbSet<Products> Products => Set<Products>();
        public ApplicationContext()
        {
            Database.EnsureCreated();   
        }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-KV67TM8\SQLEXPRESS;Trusted_Connection=True; Database=MarketPlace;TrustServerCertificate=true");
            optionsBuilder.LogTo(Console.WriteLine);
        }

    }
    
}
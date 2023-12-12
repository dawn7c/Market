using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Application;

namespace API.Data
{
    public class SampleContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString,b=>b.MigrationsAssembly("API"));

            return new ApplicationContext(builder.Options);
        }

       
    }
}

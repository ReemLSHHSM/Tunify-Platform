using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Tunify_Platform.Data
{
    public class TunifyDBContextFactory : IDesignTimeDbContextFactory<TunifyDBContext>
    {
        public TunifyDBContext CreateDbContext(string[] args)
        {
            // Set up the configuration to read from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Get the connection string from configuration
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Create options builder with SQL Server connection
            var optionsBuilder = new DbContextOptionsBuilder<TunifyDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // Return a new instance of your DbContext with the configured options
            return new TunifyDBContext(optionsBuilder.Options);
        }
    }
}

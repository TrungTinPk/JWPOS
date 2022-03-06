using JW.POS.Core;
using JW.POS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace JW.POS.Web
{
    public class TenantDbContextFactory : IDesignTimeDbContextFactory<TenantDbContext>
    {
        public TenantDbContext CreateDbContext(string[] args)
        {
            var configurationBulder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: true);

            var configuration = configurationBulder.Build();
            var connectionString = configuration.GetConnectionString("TenantConnection");

            var dbContextOptionBuilder = new DbContextOptionsBuilder<TenantDbContext>();
            dbContextOptionBuilder.UseSqlServer(connectionString);

            return new TenantDbContext(dbContextOptionBuilder.Options);
        }
    }
}

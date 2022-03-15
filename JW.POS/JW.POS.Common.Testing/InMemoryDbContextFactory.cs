using JW.POS.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace JW.POS.Common.Testing
{
    public class InMemoryTenantDbContextFactory : ITenantDbContextFactory
    {
        private readonly DbContextOptions<TenantDbContext> _options;
        public InMemoryTenantDbContextFactory(string dbName = "")
        {
            if (string.IsNullOrWhiteSpace(dbName))
            {
                dbName = Guid.NewGuid().ToString();
            }

            var builder = new DbContextOptionsBuilder<TenantDbContext>()
                .UseInMemoryDatabase(dbName)
                .EnableDetailedErrors(true)
                .EnableSensitiveDataLogging(true)
                .LogTo(s => System.Diagnostics.Debug.WriteLine(s));

            _options = builder.Options;
        }
        public TenantDbContext CreateDbContext()
        {
            var db = new TenantDbContext(_options);

            return db;
        }
    }
}

using JW.POS.Core.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JW.POS.Common.Testing
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTestingDatabase(this IServiceCollection services)
        {
            return services.AddScoped<ITenantDbContextFactory, InMemoryTenantDbContextFactory>();
        }
    }
}

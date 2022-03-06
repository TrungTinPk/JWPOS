using JW.POS.Core.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JW.POS.Core
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCoreService(
            this IServiceCollection services,
            IConfiguration config
        )
        {
            services.AddOptions<TokenSetting>("JwtToken");

            return services;
        }
    }
    
}

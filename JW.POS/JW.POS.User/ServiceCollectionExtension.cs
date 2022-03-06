using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JW.POS.User
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddUserService(this IServiceCollection services)
        {
            return services.AddScoped<IUserService, UserService>();
        }
    }
}

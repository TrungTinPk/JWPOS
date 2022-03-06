using Microsoft.Extensions.DependencyInjection;

namespace JW.POS.Web.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInternalService(
            this IServiceCollection services,
             IConfiguration config
        )
        {
            return services
                .Configure<TokenSetting>(config.GetSection("JwtToken"))
                .AddScoped<ITokenService, TokenService>()
                ;
        }
    }
}

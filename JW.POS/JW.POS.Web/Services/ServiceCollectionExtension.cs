namespace JW.POS.Web.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInternalService(
            this IServiceCollection services
        )
        {
            return services.AddScoped<ITokenService, TokenService>();
        }
    }
}

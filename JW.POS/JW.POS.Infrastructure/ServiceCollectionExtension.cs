﻿using JW.POS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JW.POS.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureService(
            this IServiceCollection services,
            string connectionString,
            bool sensitiveDataLogging,
            bool detailError
        )
        {
            return services
                .AddTenantContext(connectionString, sensitiveDataLogging, detailError)
                .AddScoped<ITenantDbContextFactory, TenantDbContextFactory>();
        }

        public static IServiceCollection AddTenantContext(
            this IServiceCollection services,
            string connectionString,
            bool sensitiveDataLogging,
            bool detailError)
        {
#if DEBUG
            sensitiveDataLogging = true;
            detailError = true;
#endif

            return services.AddDbContextFactory<TenantDbContext>(builder =>
            {
                builder.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging(sensitiveDataLogging)
                .EnableDetailedErrors(detailError)
#if DEBUG
                .LogTo(s => System.Diagnostics.Debug.WriteLine(s));
#endif

            });
        }
    }
}

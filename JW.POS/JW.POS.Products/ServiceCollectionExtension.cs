using JW.POS.Product.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JW.POS.Product
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddProductService(this IServiceCollection services)
        {
            return services.AddScoped<IProductService, ProductService>();
        }
    }
}

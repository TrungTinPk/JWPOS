using JW.POS.Core;
using JW.POS.Core.Data;
using JW.POS.Product.Models;
using Light.GuardClauses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JW.POS.Product.Services
{
    public interface IProductService
    {
        Task<AddProduct.Response> AddProductAsync(AddProduct.Request request);
    }

    public class ProductService : IProductService
    {
        private readonly ITenantDbContextFactory _tenantDbContextFactory;

        public ProductService(ITenantDbContextFactory tenantDbContextFactory)
        {
            _tenantDbContextFactory = tenantDbContextFactory;
        }

        public async Task<AddProduct.Response> AddProductAsync(AddProduct.Request request)
        {
            request.MustNotBeNull();
            request.Name.MustNotBeNullOrWhiteSpace();

            AddProduct.Response FailedResult(StatusCode statusCode)
            {
                return new AddProduct.Response
                {
                    StatusCode = statusCode
                };
            };
            if (request.WholeSalePrice > request.SalesPrice)
            {
                return FailedResult(StatusCode.WholeSale_Price_Should_Not_Greater_Than_SalePrice);
            }

            using var context = _tenantDbContextFactory.CreateDbContext();

            if (await IsProductNameExist(context, request.Name))
            {
                return FailedResult(StatusCode.Product_name_alread_exist);
            }

            var entity = context.Products.Add(new Core.Entities.Product
            {
                ProductName = request.Name,
                WholeSalePrice = request.WholeSalePrice,
                SalesPrice = request.SalesPrice,
                ImportPrice = request.ImportSale
            }).Entity;


            await context.SaveChangesAsync();

            return new AddProduct.Response
            {
                Id = entity.Id
            };
        }

        private Task<bool> IsProductNameExist(TenantDbContext context, string productName)
        {
            return context.Products.AnyAsync(p => p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));
        }
    }
}

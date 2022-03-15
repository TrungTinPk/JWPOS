using FluentAssertions;
using JW.POS.Common.Testing;
using JW.POS.Product;
using JW.POS.Product.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JW.POS.Products.Tests
{
    public class ProductTests
    {
        private IServiceProvider _serviceProvider;

        public ProductTests()
        {
            _serviceProvider = new ServiceCollection()
                .AddTestingDatabase()
                .AddProductService()
                .BuildServiceProvider();
        }

        [Fact]
        public async Task AddProductShoulDoWork()
        {
            var productService = _serviceProvider.GetRequiredService<IProductService>();

            var response = await productService.AddProductAsync(new Product.Models.AddProduct.Request
            {
                Name = "Product 1",
                WholeSalePrice = 30,
                SalesPrice = 15,
                ImportSale = 12
            });

            //Assert.Null(response.StatusCode);
            response.Should().NotBeNull();
            //response.StatusCode.Should().BeNull();
            response.Id.Should().BeGreaterThan(0);
        }
    }
}

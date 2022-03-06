using JW.POS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JW.POS.Core.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "dbo");

            builder.Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.WholeSalePrice)
                .HasPrecision(14, 2);

            builder.Property(p => p.SalesPrice)
              .HasPrecision(14, 2);

            builder.Property(p => p.ImportPrice)
              .HasPrecision(14, 2);

            builder.HasIndex(p => p.ProductName);

        }
    }
}

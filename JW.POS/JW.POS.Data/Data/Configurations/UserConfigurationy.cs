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
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo");

            builder.Property(p => p.UserName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Password)
               .IsRequired()
               .HasMaxLength(500);

            builder.Property(p => p.Email)
               .IsRequired()
               .HasMaxLength(255);

            builder.Property(p => p.FirstName)
               .IsRequired()
               .HasMaxLength(255);

            builder.Property(p => p.LastName)
               .IsRequired()
               .HasMaxLength(255);

            builder.HasIndex(p => p.UserName).IsUnique();
            builder.HasIndex(p => p.Email).IsUnique();

        }
    }
}

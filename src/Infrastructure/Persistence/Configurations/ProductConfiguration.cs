using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => new { t.CompanyPrefix, t.ItemReference });

            builder.ToTable("Product");

            builder.Property(t => t.CompanyPrefix)
                .HasMaxLength(12);

            builder.Property(t => t.CompanyName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(t => t.ItemReference)
                .HasMaxLength(7);

            builder.Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}

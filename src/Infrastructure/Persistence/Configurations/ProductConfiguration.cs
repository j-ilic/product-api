using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Entities;
using Products.Infrastructure.Persistence.SeedData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
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

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                Encoding = Encoding.UTF8
            };
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "Products.Infrastructure.Persistence.SeedData.data.csv";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<ProductData>();
                var products = records.Select(p => new Product
                {
                    CompanyName = p.CompanyName,
                    CompanyPrefix = p.CompanyPrefix,
                    ItemReference = p.ItemReference,
                    ProductName = p.ProductName
                }).ToList();

                builder.HasData(products);
            }
        }
    }
}

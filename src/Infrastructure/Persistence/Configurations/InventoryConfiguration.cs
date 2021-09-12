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
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(t => t.InventoryId);

            builder.ToTable("Inventory");

            builder.Property(t => t.InventoryId)
                .HasColumnName("InventoryID")
                .HasMaxLength(32);

            builder.Property(t => t.InventoryLocation)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(t => t.InventoryDate)
                .HasColumnType("datetime2");
        }
    }
}

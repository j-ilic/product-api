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
    public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
    {
        public void Configure(EntityTypeBuilder<InventoryItem> builder)
        {
            builder.HasKey(t => new { t.InventoryId, t.CompanyPrefix, t.ItemReference, t.SerialNumber });

            builder.ToTable("InventoryItem");

            builder.Property(t => t.InventoryId)
                .HasColumnName("InventoryID")
                .HasMaxLength(32);

            builder.Property(t => t.CompanyPrefix)
                .HasMaxLength(12);

            builder.Property(t => t.ItemReference)
                .HasMaxLength(7);

            builder.Property(t => t.SerialNumber)
                .HasMaxLength(12);

            builder.Property(t => t.Filter)
                .HasColumnType("tinyint");

            builder.Property(t => t.HexTag)
                .IsRequired()
                .HasMaxLength(24);

            builder.Property(t => t.TagUri)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(it => it.Inventory)
                .WithMany(i => i.InventoryItems)
                .HasForeignKey(it => it.InventoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryItem_Inventory");

            builder.HasOne(it => it.Product)
                .WithMany(p => p.InventoryItems)
                .HasForeignKey(it => new { it.CompanyPrefix, it.ItemReference })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryItem_Product");
        }
    }
}

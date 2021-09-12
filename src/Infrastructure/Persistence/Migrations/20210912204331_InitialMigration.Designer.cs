﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Products.Infrastructure.Persistence;

namespace Products.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210912204331_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Products.Domain.Entities.Inventory", b =>
                {
                    b.Property<string>("InventoryId")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("InventoryID");

                    b.Property<DateTime>("InventoryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InventoryLocation")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("Products.Domain.Entities.InventoryItem", b =>
                {
                    b.Property<string>("InventoryId")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("InventoryID");

                    b.Property<string>("CompanyPrefix")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("ItemReference")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<byte>("Filter")
                        .HasColumnType("tinyint");

                    b.Property<string>("HexTag")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("TagUri")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("InventoryId", "CompanyPrefix", "ItemReference", "SerialNumber");

                    b.HasIndex("CompanyPrefix", "ItemReference");

                    b.ToTable("InventoryItem");
                });

            modelBuilder.Entity("Products.Domain.Entities.Product", b =>
                {
                    b.Property<string>("CompanyPrefix")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("ItemReference")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CompanyPrefix", "ItemReference");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Products.Domain.Entities.InventoryItem", b =>
                {
                    b.HasOne("Products.Domain.Entities.Inventory", "Inventory")
                        .WithMany("InventoryItems")
                        .HasForeignKey("InventoryId")
                        .HasConstraintName("FK_InventoryItem_Inventory")
                        .IsRequired();

                    b.HasOne("Products.Domain.Entities.Product", "Product")
                        .WithMany("InventoryItems")
                        .HasForeignKey("CompanyPrefix", "ItemReference")
                        .HasConstraintName("FK_InventoryItem_Product")
                        .IsRequired();

                    b.Navigation("Inventory");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Products.Domain.Entities.Inventory", b =>
                {
                    b.Navigation("InventoryItems");
                });

            modelBuilder.Entity("Products.Domain.Entities.Product", b =>
                {
                    b.Navigation("InventoryItems");
                });
#pragma warning restore 612, 618
        }
    }
}

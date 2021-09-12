using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Infrastructure.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryID = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    InventoryLocation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    InventoryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    CompanyPrefix = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    ItemReference = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => new { x.CompanyPrefix, x.ItemReference });
                });

            migrationBuilder.CreateTable(
                name: "InventoryItem",
                columns: table => new
                {
                    InventoryID = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CompanyPrefix = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    ItemReference = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Filter = table.Column<byte>(type: "tinyint", nullable: false),
                    TagUri = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HexTag = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItem", x => new { x.InventoryID, x.CompanyPrefix, x.ItemReference, x.SerialNumber });
                    table.ForeignKey(
                        name: "FK_InventoryItem_Inventory",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryItem_Product",
                        columns: x => new { x.CompanyPrefix, x.ItemReference },
                        principalTable: "Product",
                        principalColumns: new[] { "CompanyPrefix", "ItemReference" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_CompanyPrefix_ItemReference",
                table: "InventoryItem",
                columns: new[] { "CompanyPrefix", "ItemReference" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItem");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JW.POS.Infrastructure.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    WholeSalePrice = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    SalesPrice = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    ImportPrice = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductName",
                schema: "dbo",
                table: "Products",
                column: "ProductName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "dbo");
        }
    }
}

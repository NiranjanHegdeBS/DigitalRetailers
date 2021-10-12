using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalRetailers.Migrations
{
    public partial class LaptopQuantityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "laptopQuantity",
                table: "Laptops",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "laptopQuantity",
                table: "Laptops");
        }
    }
}

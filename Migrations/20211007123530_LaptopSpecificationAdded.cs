using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalRetailers.Migrations
{
    public partial class LaptopSpecificationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "laptopSpecification",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "laptopSpecification",
                table: "Laptops");
        }
    }
}

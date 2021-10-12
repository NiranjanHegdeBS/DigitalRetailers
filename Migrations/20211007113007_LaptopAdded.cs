using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalRetailers.Migrations
{
    public partial class LaptopAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    laptopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    laptopName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    laptopPrice = table.Column<float>(type: "real", nullable: false),
                    laptopImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.laptopId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laptops");
        }
    }
}

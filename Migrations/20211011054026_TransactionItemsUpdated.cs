using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalRetailers.Migrations
{
    public partial class TransactionItemsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "purchasedItems",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "purchasedItems",
                table: "Transactions");
        }
    }
}

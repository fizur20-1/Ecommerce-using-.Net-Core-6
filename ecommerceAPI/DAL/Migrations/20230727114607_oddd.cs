using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class oddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Offers_Offer_Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Offer_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Offer_Id",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Offer_Id",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Offer_Id",
                table: "Products",
                column: "Offer_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Offers_Offer_Id",
                table: "Products",
                column: "Offer_Id",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

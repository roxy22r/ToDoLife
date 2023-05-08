using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoLife_App.Migrations
{
    public partial class level6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Level_Price_PriceId",
                table: "Level");

            migrationBuilder.DropIndex(
                name: "IX_Level_PriceId",
                table: "Level");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Level");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "Level",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Level_PriceId",
                table: "Level",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Level_Price_PriceId",
                table: "Level",
                column: "PriceId",
                principalTable: "Price",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

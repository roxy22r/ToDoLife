using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoLife_App.Migrations
{
    public partial class Prices2 : Migration
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

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Price",
                newName: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_LevelId",
                table: "Price",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Price_Level_LevelId",
                table: "Price",
                column: "LevelId",
                principalTable: "Level",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price_Level_LevelId",
                table: "Price");

            migrationBuilder.DropIndex(
                name: "IX_Price_LevelId",
                table: "Price");

            migrationBuilder.RenameColumn(
                name: "LevelId",
                table: "Price",
                newName: "Level");

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "Level",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Level_PriceId",
                table: "Level",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Level_Price_PriceId",
                table: "Level",
                column: "PriceId",
                principalTable: "Price",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoLife_App.Migrations
{
    public partial class level8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Price",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "User",
                table: "Price",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Price");
        }
    }
}

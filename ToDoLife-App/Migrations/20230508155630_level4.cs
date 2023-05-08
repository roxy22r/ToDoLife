using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoLife_App.Migrations
{
    public partial class level4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Level_Price_PriceId",
                table: "Level");

            migrationBuilder.AlterColumn<int>(
                name: "PriceId",
                table: "Level",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Level_Price_PriceId",
                table: "Level",
                column: "PriceId",
                principalTable: "Price",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Level_Price_PriceId",
                table: "Level");

            migrationBuilder.AlterColumn<int>(
                name: "PriceId",
                table: "Level",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Level_Price_PriceId",
                table: "Level",
                column: "PriceId",
                principalTable: "Price",
                principalColumn: "Id");
        }
    }
}

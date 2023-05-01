using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoLife_App.Data.Migrations
{
    public partial class Update_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prices",
                table: "ToDo");

            migrationBuilder.RenameColumn(
                name: "TodoTitle",
                table: "ToDo",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "ToDo",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "ToDo");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ToDo",
                newName: "TodoTitle");

            migrationBuilder.AddColumn<string>(
                name: "prices",
                table: "ToDo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

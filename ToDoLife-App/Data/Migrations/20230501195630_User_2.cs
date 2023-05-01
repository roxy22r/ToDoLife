using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoLife_App.Data.Migrations
{
    public partial class User_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ToDo",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ToDo",
                newName: "ID");
        }
    }
}

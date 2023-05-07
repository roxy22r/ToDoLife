using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoLife_App.Migrations
{
    public partial class UserConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProgrammConfig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilterTodoListDueToday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProgrammConfig", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProgrammConfig");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoLife_App.Migrations
{
    public partial class UserConfig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "User",
                table: "Level",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Level");
        }
    }
}

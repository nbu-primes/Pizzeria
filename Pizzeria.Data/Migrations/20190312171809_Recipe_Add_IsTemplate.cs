using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.Data.Migrations
{
    public partial class Recipe_Add_IsTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Key",
                table: "Recipes",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "IsTemplate",
                table: "Recipes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTemplate",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Recipes",
                newName: "Key");
        }
    }
}

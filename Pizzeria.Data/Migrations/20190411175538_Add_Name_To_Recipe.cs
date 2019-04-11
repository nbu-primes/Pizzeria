using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.Data.Migrations
{
    public partial class Add_Name_To_Recipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Recipes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Additives",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("62326247-6562-4584-83da-225b000376a6"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Pizza with fresh mushrooms", "Mushroom pizza" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f7453db5-628d-450f-97ce-ca1a5a1b9f0d"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "A tasty Pepperoni", "Pepperoni" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b86f5a2-1978-46e3-a0b6-edbb6b558efc"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 54, 7, 163, 253, 40, 189, 226, 20, 245, 209, 159, 19, 50, 239, 18, 79, 77, 69, 127, 132, 188, 129, 50, 128, 31, 159, 211, 207, 126, 207, 255, 151, 33, 66, 165, 203, 171, 22, 64, 105, 88, 171, 204, 253, 189, 177, 13, 188, 152, 198, 147, 167, 68, 180, 92, 178, 94, 33, 180, 27, 27, 206, 125, 243 }, new byte[] { 71, 80, 83, 81, 90, 82, 72, 57, 69, 84, 48, 72, 83, 90, 79, 69, 74, 50, 55, 85, 86, 71, 85, 69, 65, 48, 71, 83, 90, 85, 76, 56, 50, 78, 68, 78, 53, 85, 82, 89, 82, 88, 80, 49, 87, 89, 48, 48, 52, 69, 80, 84, 65, 51, 75, 56, 68, 74, 90, 70, 86, 50, 69, 70, 86, 51, 65, 56, 86, 68, 65, 70, 56, 88, 88, 65, 76, 85, 69, 86, 89, 49, 65, 50, 71, 73, 53, 50, 48, 65, 55, 79, 75, 73, 83, 83, 79, 55, 80, 66, 65, 72, 79, 83, 57, 66, 69, 51, 74, 90, 52, 80, 81, 80, 70, 55, 57, 84, 82, 90, 49, 87, 70, 86, 86, 86, 53, 76 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c643b944-53d9-4a0c-9922-3486558b9129"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 54, 7, 163, 253, 40, 189, 226, 20, 245, 209, 159, 19, 50, 239, 18, 79, 77, 69, 127, 132, 188, 129, 50, 128, 31, 159, 211, 207, 126, 207, 255, 151, 33, 66, 165, 203, 171, 22, 64, 105, 88, 171, 204, 253, 189, 177, 13, 188, 152, 198, 147, 167, 68, 180, 92, 178, 94, 33, 180, 27, 27, 206, 125, 243 }, new byte[] { 71, 80, 83, 81, 90, 82, 72, 57, 69, 84, 48, 72, 83, 90, 79, 69, 74, 50, 55, 85, 86, 71, 85, 69, 65, 48, 71, 83, 90, 85, 76, 56, 50, 78, 68, 78, 53, 85, 82, 89, 82, 88, 80, 49, 87, 89, 48, 48, 52, 69, 80, 84, 65, 51, 75, 56, 68, 74, 90, 70, 86, 50, 69, 70, 86, 51, 65, 56, 86, 68, 65, 70, 56, 88, 88, 65, 76, 85, 69, 86, 89, 49, 65, 50, 71, 73, 53, 50, 48, 65, 55, 79, 75, 73, 83, 83, 79, 55, 80, 66, 65, 72, 79, 83, 57, 66, 69, 51, 74, 90, 52, 80, 81, 80, 70, 55, 57, 84, 82, 90, 49, 87, 70, 86, 86, 86, 53, 76 } });

            migrationBuilder.CreateIndex(
                name: "IX_Additives_Name",
                table: "Additives",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Additives_Name",
                table: "Additives");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Recipes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Additives",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("62326247-6562-4584-83da-225b000376a6"),
                column: "Description",
                value: "Mushroom pizza");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f7453db5-628d-450f-97ce-ca1a5a1b9f0d"),
                column: "Description",
                value: "Pepperoni");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b86f5a2-1978-46e3-a0b6-edbb6b558efc"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 54, 7, 163, 253, 40, 189, 226, 20, 245, 209, 159, 19, 50, 239, 18, 79, 77, 69, 127, 132, 188, 129, 50, 128, 31, 159, 211, 207, 126, 207, 255, 151, 33, 66, 165, 203, 171, 22, 64, 105, 88, 171, 204, 253, 189, 177, 13, 188, 152, 198, 147, 167, 68, 180, 92, 178, 94, 33, 180, 27, 27, 206, 125, 243 }, new byte[] { 71, 80, 83, 81, 90, 82, 72, 57, 69, 84, 48, 72, 83, 90, 79, 69, 74, 50, 55, 85, 86, 71, 85, 69, 65, 48, 71, 83, 90, 85, 76, 56, 50, 78, 68, 78, 53, 85, 82, 89, 82, 88, 80, 49, 87, 89, 48, 48, 52, 69, 80, 84, 65, 51, 75, 56, 68, 74, 90, 70, 86, 50, 69, 70, 86, 51, 65, 56, 86, 68, 65, 70, 56, 88, 88, 65, 76, 85, 69, 86, 89, 49, 65, 50, 71, 73, 53, 50, 48, 65, 55, 79, 75, 73, 83, 83, 79, 55, 80, 66, 65, 72, 79, 83, 57, 66, 69, 51, 74, 90, 52, 80, 81, 80, 70, 55, 57, 84, 82, 90, 49, 87, 70, 86, 86, 86, 53, 76 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c643b944-53d9-4a0c-9922-3486558b9129"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 54, 7, 163, 253, 40, 189, 226, 20, 245, 209, 159, 19, 50, 239, 18, 79, 77, 69, 127, 132, 188, 129, 50, 128, 31, 159, 211, 207, 126, 207, 255, 151, 33, 66, 165, 203, 171, 22, 64, 105, 88, 171, 204, 253, 189, 177, 13, 188, 152, 198, 147, 167, 68, 180, 92, 178, 94, 33, 180, 27, 27, 206, 125, 243 }, new byte[] { 71, 80, 83, 81, 90, 82, 72, 57, 69, 84, 48, 72, 83, 90, 79, 69, 74, 50, 55, 85, 86, 71, 85, 69, 65, 48, 71, 83, 90, 85, 76, 56, 50, 78, 68, 78, 53, 85, 82, 89, 82, 88, 80, 49, 87, 89, 48, 48, 52, 69, 80, 84, 65, 51, 75, 56, 68, 74, 90, 70, 86, 50, 69, 70, 86, 51, 65, 56, 86, 68, 65, 70, 56, 88, 88, 65, 76, 85, 69, 86, 89, 49, 65, 50, 71, 73, 53, 50, 48, 65, 55, 79, 75, 73, 83, 83, 79, 55, 80, 66, 65, 72, 79, 83, 57, 66, 69, 51, 74, 90, 52, 80, 81, 80, 70, 55, 57, 84, 82, 90, 49, 87, 70, 86, 86, 86, 53, 76 } });
        }
    }
}

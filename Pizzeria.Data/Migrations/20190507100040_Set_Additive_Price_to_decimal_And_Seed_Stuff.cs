using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.Data.Migrations
{
    public partial class Set_Additive_Price_to_decimal_And_Seed_Stuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Additives",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Additives",
                keyColumn: "Id",
                keyValue: new Guid("1524f795-ad1c-45cc-835a-f971a22735e9"),
                column: "Price",
                value: 0.99m);

            migrationBuilder.UpdateData(
                table: "Additives",
                keyColumn: "Id",
                keyValue: new Guid("20a5f42a-9585-4d55-a4fb-d73d27b34ffd"),
                column: "Price",
                value: 2.80m);

            migrationBuilder.UpdateData(
                table: "Additives",
                keyColumn: "Id",
                keyValue: new Guid("38de00d4-a8a2-4586-8f39-a00ff5a8ba71"),
                column: "Price",
                value: 1.20m);

            migrationBuilder.UpdateData(
                table: "Additives",
                keyColumn: "Id",
                keyValue: new Guid("69152cbc-8c3a-4444-9914-ab95a16b4485"),
                column: "Price",
                value: 1.50m);

            migrationBuilder.UpdateData(
                table: "Additives",
                keyColumn: "Id",
                keyValue: new Guid("9c068dfe-120a-4bc8-8574-68211a277784"),
                column: "Price",
                value: 0.99m);

            migrationBuilder.UpdateData(
                table: "Additives",
                keyColumn: "Id",
                keyValue: new Guid("c11e6a87-11b3-4e64-9c9f-62a019622384"),
                column: "Price",
                value: 2.20m);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e"),
                column: "ImagePath",
                value: "https://www.thebittersideofsweet.com/wp-content/uploads/2016/09/IMG_5853-1.jpg");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Additives",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.UpdateData(
                table: "Additives",
                keyColumn: "Id",
                keyValue: new Guid("1524f795-ad1c-45cc-835a-f971a22735e9"),
                column: "Price",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Additives",
                keyColumn: "Id",
                keyValue: new Guid("20a5f42a-9585-4d55-a4fb-d73d27b34ffd"),
                column: "Price",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Additives",
                keyColumn: "Id",
                keyValue: new Guid("38de00d4-a8a2-4586-8f39-a00ff5a8ba71"),
                column: "Price",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Additives",
                keyColumn: "Id",
                keyValue: new Guid("69152cbc-8c3a-4444-9914-ab95a16b4485"),
                column: "Price",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Additives",
                keyColumn: "Id",
                keyValue: new Guid("9c068dfe-120a-4bc8-8574-68211a277784"),
                column: "Price",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Additives",
                keyColumn: "Id",
                keyValue: new Guid("c11e6a87-11b3-4e64-9c9f-62a019622384"),
                column: "Price",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e"),
                column: "ImagePath",
                value: "https://static-communitytable.parade.com/wp-content/uploads/2017/01/IMG_5857-1.jpg");

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

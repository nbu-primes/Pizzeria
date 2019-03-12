using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.Data.Migrations
{
    public partial class Order_History_one_to_one_rel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderHistory_OrderId",
                table: "OrderHistory");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderHistoryId",
                table: "Orders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_OrderId",
                table: "OrderHistory",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderHistory_OrderId",
                table: "OrderHistory");

            migrationBuilder.DropColumn(
                name: "OrderHistoryId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_OrderId",
                table: "OrderHistory",
                column: "OrderId");
        }
    }
}

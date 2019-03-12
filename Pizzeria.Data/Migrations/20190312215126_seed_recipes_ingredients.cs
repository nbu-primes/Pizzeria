using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.Data.Migrations
{
    public partial class seed_recipes_ingredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("4822d030-b2da-4fdb-85e6-4559c2029eac"), "Salami", 5m },
                    { new Guid("c50f4d0a-6cac-436e-b5c8-b0f5d9ca312d"), "Tomato sauce", 2m },
                    { new Guid("ab8e13dc-a412-4959-b626-786105564735"), "Cheese", 2m },
                    { new Guid("eb372a85-ff19-48a2-97de-2d888b664e93"), "Mushrooms", 2m }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "ImageUrl", "IsTemplate", "OrderId", "Price", "Weight" },
                values: new object[,]
                {
                    { new Guid("f7453db5-628d-450f-97ce-ca1a5a1b9f0d"), "Pepperoni", "https://www.silviocicchi.com/pizzachef/wp-content/uploads/2015/02/p-evid1-672x372.jpg", true, null, 13.5, 1500.0 },
                    { new Guid("62326247-6562-4584-83da-225b000376a6"), "Mushroom pizza", "https://d2814mmsvlryp1.cloudfront.net/wp-content/uploads/2017/03/WGC-mushroom-sheet-pan-pizza-1-copy-2.jpg", true, null, 11.99, 1300.0 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredient",
                columns: new[] { "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { new Guid("4822d030-b2da-4fdb-85e6-4559c2029eac"), new Guid("f7453db5-628d-450f-97ce-ca1a5a1b9f0d") },
                    { new Guid("c50f4d0a-6cac-436e-b5c8-b0f5d9ca312d"), new Guid("f7453db5-628d-450f-97ce-ca1a5a1b9f0d") },
                    { new Guid("ab8e13dc-a412-4959-b626-786105564735"), new Guid("62326247-6562-4584-83da-225b000376a6") },
                    { new Guid("eb372a85-ff19-48a2-97de-2d888b664e93"), new Guid("62326247-6562-4584-83da-225b000376a6") }
                });  
        }
    }
}

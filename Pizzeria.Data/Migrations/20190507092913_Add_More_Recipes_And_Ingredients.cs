using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzeria.Data.Migrations
{
    public partial class Add_More_Recipes_And_Ingredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("1f8c120b-a77e-4e91-96fd-ca318f7e192a"), "Garlic", 0.5m },
                    { new Guid("5361e8fc-1779-4642-a31d-9bf1d480f7da"), "Mozzarella", 1.2m },
                    { new Guid("2fb3f367-efdb-4186-b164-4836a660e1c4"), "Onion", 0.5m },
                    { new Guid("67847eae-9541-4637-b84d-17128fd292a0"), "Cherry Tomatoes", 1.50m },
                    { new Guid("6435f0e7-55a6-4a74-8211-ee58379dde1a"), "Fresh Basil", 1m },
                    { new Guid("dbd5ec8e-5b4a-4263-a69f-a48b67fa5d98"), "Fresh Peppers", 1.5m },
                    { new Guid("0e3ec007-3546-4e01-afd1-1c153c0ce93b"), "Prosciutto Crudo", 2.30m },
                    { new Guid("eaa1f9f4-67cd-4dfc-8557-42dfa017b6ba"), "Blue Cheese", 1.20m }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "ImagePath", "IsTemplate", "Name", "OrderId", "Price", "Weight" },
                values: new object[,]
                {
                    { new Guid("8875f694-4f87-484d-bb2b-413fa5c7c369"), "Sometimes you just can't beat a classic like fresh and simple Margherita Pizza", "http://www.fnstatic.co.uk/images/content/recipe/margherita-pizza.jpeg", true, "Margherita Pizza", null, 9.99, 1300.0 },
                    { new Guid("a0a75f4e-a04c-4306-855d-9f06136a7717"), "A calzone is an Italian oven-baked folded pizza that originated in Naples", "http://www.fnstatic.co.uk/images/content/recipe/calzone-pizza.jpg", true, "Calzone Pizza", null, 13.0, 1300.0 },
                    { new Guid("501bd33b-92b6-48e6-87ec-0e5d5a2f07e8"), "It is an Italian style snack that is tasty and made it quickly", "http://www.fnstatic.co.uk/images/content/recipe/bruschetta-pizzaiola.jpeg", true, "Bruschetta Pizzaiola", null, 8.5, 1000.0 },
                    { new Guid("267a56e4-1342-4cec-973e-74f84909b110"), "Ortolano in italian means 'from the vegetable patch'. It is a great vegetarian pizza and a somewhat healthier option as it’s made with grilled eggplant, roasted bell pepper and artichoke hearts", "https://www.manusmenu.com/wp-content/uploads/2015/08/1-Pizza-Ortolana-4-1-of-1.jpg", true, "Pizza Ortolana", null, 9.99, 1000.0 },
                    { new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e"), "Spread bases with pizza sauce and sprinkle with pizza cheese and blue cheese", "https://static-communitytable.parade.com/wp-content/uploads/2017/01/IMG_5857-1.jpg", true, "Blue Cheese Prosciutto Pizza", null, 12.3, 1000.0 }
                });

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

            migrationBuilder.InsertData(
                table: "RecipeIngredient",
                columns: new[] { "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { new Guid("c50f4d0a-6cac-436e-b5c8-b0f5d9ca312d"), new Guid("8875f694-4f87-484d-bb2b-413fa5c7c369") },
                    { new Guid("1f8c120b-a77e-4e91-96fd-ca318f7e192a"), new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e") },
                    { new Guid("c50f4d0a-6cac-436e-b5c8-b0f5d9ca312d"), new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e") },
                    { new Guid("dbd5ec8e-5b4a-4263-a69f-a48b67fa5d98"), new Guid("267a56e4-1342-4cec-973e-74f84909b110") },
                    { new Guid("6435f0e7-55a6-4a74-8211-ee58379dde1a"), new Guid("267a56e4-1342-4cec-973e-74f84909b110") },
                    { new Guid("5361e8fc-1779-4642-a31d-9bf1d480f7da"), new Guid("267a56e4-1342-4cec-973e-74f84909b110") },
                    { new Guid("c50f4d0a-6cac-436e-b5c8-b0f5d9ca312d"), new Guid("267a56e4-1342-4cec-973e-74f84909b110") },
                    { new Guid("6435f0e7-55a6-4a74-8211-ee58379dde1a"), new Guid("501bd33b-92b6-48e6-87ec-0e5d5a2f07e8") },
                    { new Guid("67847eae-9541-4637-b84d-17128fd292a0"), new Guid("501bd33b-92b6-48e6-87ec-0e5d5a2f07e8") },
                    { new Guid("5361e8fc-1779-4642-a31d-9bf1d480f7da"), new Guid("501bd33b-92b6-48e6-87ec-0e5d5a2f07e8") },
                    { new Guid("2fb3f367-efdb-4186-b164-4836a660e1c4"), new Guid("a0a75f4e-a04c-4306-855d-9f06136a7717") },
                    { new Guid("5361e8fc-1779-4642-a31d-9bf1d480f7da"), new Guid("a0a75f4e-a04c-4306-855d-9f06136a7717") },
                    { new Guid("1f8c120b-a77e-4e91-96fd-ca318f7e192a"), new Guid("a0a75f4e-a04c-4306-855d-9f06136a7717") },
                    { new Guid("6435f0e7-55a6-4a74-8211-ee58379dde1a"), new Guid("8875f694-4f87-484d-bb2b-413fa5c7c369") },
                    { new Guid("5361e8fc-1779-4642-a31d-9bf1d480f7da"), new Guid("8875f694-4f87-484d-bb2b-413fa5c7c369") },
                    { new Guid("1f8c120b-a77e-4e91-96fd-ca318f7e192a"), new Guid("8875f694-4f87-484d-bb2b-413fa5c7c369") },
                    { new Guid("0e3ec007-3546-4e01-afd1-1c153c0ce93b"), new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e") },
                    { new Guid("eaa1f9f4-67cd-4dfc-8557-42dfa017b6ba"), new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("0e3ec007-3546-4e01-afd1-1c153c0ce93b"), new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("1f8c120b-a77e-4e91-96fd-ca318f7e192a"), new Guid("8875f694-4f87-484d-bb2b-413fa5c7c369") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("1f8c120b-a77e-4e91-96fd-ca318f7e192a"), new Guid("a0a75f4e-a04c-4306-855d-9f06136a7717") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("1f8c120b-a77e-4e91-96fd-ca318f7e192a"), new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("2fb3f367-efdb-4186-b164-4836a660e1c4"), new Guid("a0a75f4e-a04c-4306-855d-9f06136a7717") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("5361e8fc-1779-4642-a31d-9bf1d480f7da"), new Guid("267a56e4-1342-4cec-973e-74f84909b110") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("5361e8fc-1779-4642-a31d-9bf1d480f7da"), new Guid("501bd33b-92b6-48e6-87ec-0e5d5a2f07e8") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("5361e8fc-1779-4642-a31d-9bf1d480f7da"), new Guid("8875f694-4f87-484d-bb2b-413fa5c7c369") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("5361e8fc-1779-4642-a31d-9bf1d480f7da"), new Guid("a0a75f4e-a04c-4306-855d-9f06136a7717") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("6435f0e7-55a6-4a74-8211-ee58379dde1a"), new Guid("267a56e4-1342-4cec-973e-74f84909b110") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("6435f0e7-55a6-4a74-8211-ee58379dde1a"), new Guid("501bd33b-92b6-48e6-87ec-0e5d5a2f07e8") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("6435f0e7-55a6-4a74-8211-ee58379dde1a"), new Guid("8875f694-4f87-484d-bb2b-413fa5c7c369") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("67847eae-9541-4637-b84d-17128fd292a0"), new Guid("501bd33b-92b6-48e6-87ec-0e5d5a2f07e8") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("c50f4d0a-6cac-436e-b5c8-b0f5d9ca312d"), new Guid("267a56e4-1342-4cec-973e-74f84909b110") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("c50f4d0a-6cac-436e-b5c8-b0f5d9ca312d"), new Guid("8875f694-4f87-484d-bb2b-413fa5c7c369") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("c50f4d0a-6cac-436e-b5c8-b0f5d9ca312d"), new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("dbd5ec8e-5b4a-4263-a69f-a48b67fa5d98"), new Guid("267a56e4-1342-4cec-973e-74f84909b110") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredient",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("eaa1f9f4-67cd-4dfc-8557-42dfa017b6ba"), new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e") });

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("0e3ec007-3546-4e01-afd1-1c153c0ce93b"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("1f8c120b-a77e-4e91-96fd-ca318f7e192a"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("2fb3f367-efdb-4186-b164-4836a660e1c4"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("5361e8fc-1779-4642-a31d-9bf1d480f7da"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("6435f0e7-55a6-4a74-8211-ee58379dde1a"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("67847eae-9541-4637-b84d-17128fd292a0"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("dbd5ec8e-5b4a-4263-a69f-a48b67fa5d98"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("eaa1f9f4-67cd-4dfc-8557-42dfa017b6ba"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("267a56e4-1342-4cec-973e-74f84909b110"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("501bd33b-92b6-48e6-87ec-0e5d5a2f07e8"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("8875f694-4f87-484d-bb2b-413fa5c7c369"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a0a75f4e-a04c-4306-855d-9f06136a7717"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e"));

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

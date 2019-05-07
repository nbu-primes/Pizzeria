﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pizzeria.Data;

namespace Pizzeria.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190507100040_Set_Additive_Price_to_decimal_And_Seed_Stuff")]
    partial class Set_Additive_Price_to_decimal_And_Seed_Stuff
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pizzeria.Models.Additive", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Additives");

                    b.HasData(
                        new { Id = new Guid("38de00d4-a8a2-4586-8f39-a00ff5a8ba71"), Name = "Soda", Price = 1.20m },
                        new { Id = new Guid("69152cbc-8c3a-4444-9914-ab95a16b4485"), Name = "Coke", Price = 1.50m },
                        new { Id = new Guid("c11e6a87-11b3-4e64-9c9f-62a019622384"), Name = "French Fries", Price = 2.20m },
                        new { Id = new Guid("1524f795-ad1c-45cc-835a-f971a22735e9"), Name = "Hot Sauce", Price = 0.99m },
                        new { Id = new Guid("9c068dfe-120a-4bc8-8574-68211a277784"), Name = "Barbecue Sauce", Price = 0.99m },
                        new { Id = new Guid("20a5f42a-9585-4d55-a4fb-d73d27b34ffd"), Name = "Brownie", Price = 2.80m }
                    );
                });

            modelBuilder.Entity("Pizzeria.Models.Caterer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsAvailable");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Caterers");

                    b.HasData(
                        new { Id = new Guid("b89ca9ab-ae08-4f34-8369-4397b47702d1"), IsAvailable = true, Name = "Food Panda" },
                        new { Id = new Guid("d6c569f9-0df2-4c6e-967f-68a2684c22da"), IsAvailable = true, Name = "Takeaway" }
                    );
                });

            modelBuilder.Entity("Pizzeria.Models.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new { Id = new Guid("4822d030-b2da-4fdb-85e6-4559c2029eac"), Name = "Salami", Price = 5m },
                        new { Id = new Guid("c50f4d0a-6cac-436e-b5c8-b0f5d9ca312d"), Name = "Tomato sauce", Price = 2m },
                        new { Id = new Guid("ab8e13dc-a412-4959-b626-786105564735"), Name = "Cheese", Price = 2m },
                        new { Id = new Guid("eb372a85-ff19-48a2-97de-2d888b664e93"), Name = "Mushrooms", Price = 2m },
                        new { Id = new Guid("1f8c120b-a77e-4e91-96fd-ca318f7e192a"), Name = "Garlic", Price = 0.5m },
                        new { Id = new Guid("5361e8fc-1779-4642-a31d-9bf1d480f7da"), Name = "Mozzarella", Price = 1.2m },
                        new { Id = new Guid("2fb3f367-efdb-4186-b164-4836a660e1c4"), Name = "Onion", Price = 0.5m },
                        new { Id = new Guid("67847eae-9541-4637-b84d-17128fd292a0"), Name = "Cherry Tomatoes", Price = 1.50m },
                        new { Id = new Guid("6435f0e7-55a6-4a74-8211-ee58379dde1a"), Name = "Fresh Basil", Price = 1m },
                        new { Id = new Guid("dbd5ec8e-5b4a-4263-a69f-a48b67fa5d98"), Name = "Fresh Peppers", Price = 1.5m },
                        new { Id = new Guid("0e3ec007-3546-4e01-afd1-1c153c0ce93b"), Name = "Prosciutto Crudo", Price = 2.30m },
                        new { Id = new Guid("eaa1f9f4-67cd-4dfc-8557-42dfa017b6ba"), Name = "Blue Cheese", Price = 1.20m }
                    );
                });

            modelBuilder.Entity("Pizzeria.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<Guid>("CatererId");

                    b.Property<decimal>("TotalPrice");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CatererId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Pizzeria.Models.OrderAdditive", b =>
                {
                    b.Property<Guid>("OrderId");

                    b.Property<Guid>("AdditiveId");

                    b.Property<int>("Count");

                    b.HasKey("OrderId", "AdditiveId", "Count");

                    b.HasIndex("AdditiveId");

                    b.ToTable("OrderAdditive");
                });

            modelBuilder.Entity("Pizzeria.Models.OrderHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("OrderCompleted");

                    b.Property<Guid>("OrderId");

                    b.Property<DateTime>("OrderStarted");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("OrderHistory");
                });

            modelBuilder.Entity("Pizzeria.Models.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ImagePath")
                        .IsRequired();

                    b.Property<bool>("IsTemplate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("OrderId");

                    b.Property<double>("Price");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new { Id = new Guid("f7453db5-628d-450f-97ce-ca1a5a1b9f0d"), Description = "A tasty Pepperoni", ImagePath = "https://www.silviocicchi.com/pizzachef/wp-content/uploads/2015/02/p-evid1-672x372.jpg", IsTemplate = true, Name = "Pepperoni", Price = 13.5, Weight = 1500.0 },
                        new { Id = new Guid("62326247-6562-4584-83da-225b000376a6"), Description = "Pizza with fresh mushrooms", ImagePath = "https://d2814mmsvlryp1.cloudfront.net/wp-content/uploads/2017/03/WGC-mushroom-sheet-pan-pizza-1-copy-2.jpg", IsTemplate = true, Name = "Mushroom pizza", Price = 11.99, Weight = 1300.0 },
                        new { Id = new Guid("8875f694-4f87-484d-bb2b-413fa5c7c369"), Description = "Sometimes you just can't beat a classic like fresh and simple Margherita Pizza", ImagePath = "http://www.fnstatic.co.uk/images/content/recipe/margherita-pizza.jpeg", IsTemplate = true, Name = "Margherita Pizza", Price = 9.99, Weight = 1300.0 },
                        new { Id = new Guid("a0a75f4e-a04c-4306-855d-9f06136a7717"), Description = "A calzone is an Italian oven-baked folded pizza that originated in Naples", ImagePath = "http://www.fnstatic.co.uk/images/content/recipe/calzone-pizza.jpg", IsTemplate = true, Name = "Calzone Pizza", Price = 13.0, Weight = 1300.0 },
                        new { Id = new Guid("501bd33b-92b6-48e6-87ec-0e5d5a2f07e8"), Description = "It is an Italian style snack that is tasty and made it quickly", ImagePath = "http://www.fnstatic.co.uk/images/content/recipe/bruschetta-pizzaiola.jpeg", IsTemplate = true, Name = "Bruschetta Pizzaiola", Price = 8.5, Weight = 1000.0 },
                        new { Id = new Guid("267a56e4-1342-4cec-973e-74f84909b110"), Description = "Ortolano in italian means 'from the vegetable patch'. It is a great vegetarian pizza and a somewhat healthier option as it’s made with grilled eggplant, roasted bell pepper and artichoke hearts", ImagePath = "https://www.manusmenu.com/wp-content/uploads/2015/08/1-Pizza-Ortolana-4-1-of-1.jpg", IsTemplate = true, Name = "Pizza Ortolana", Price = 9.99, Weight = 1000.0 },
                        new { Id = new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e"), Description = "Spread bases with pizza sauce and sprinkle with pizza cheese and blue cheese", ImagePath = "https://www.thebittersideofsweet.com/wp-content/uploads/2016/09/IMG_5853-1.jpg", IsTemplate = true, Name = "Blue Cheese Prosciutto Pizza", Price = 12.3, Weight = 1000.0 }
                    );
                });

            modelBuilder.Entity("Pizzeria.Models.RecipeIngredient", b =>
                {
                    b.Property<Guid>("IngredientId");

                    b.Property<Guid>("RecipeId");

                    b.HasKey("IngredientId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeIngredient");

                    b.HasData(
                        new { IngredientId = new Guid("4822d030-b2da-4fdb-85e6-4559c2029eac"), RecipeId = new Guid("f7453db5-628d-450f-97ce-ca1a5a1b9f0d") },
                        new { IngredientId = new Guid("c50f4d0a-6cac-436e-b5c8-b0f5d9ca312d"), RecipeId = new Guid("f7453db5-628d-450f-97ce-ca1a5a1b9f0d") },
                        new { IngredientId = new Guid("ab8e13dc-a412-4959-b626-786105564735"), RecipeId = new Guid("62326247-6562-4584-83da-225b000376a6") },
                        new { IngredientId = new Guid("eb372a85-ff19-48a2-97de-2d888b664e93"), RecipeId = new Guid("62326247-6562-4584-83da-225b000376a6") },
                        new { IngredientId = new Guid("c50f4d0a-6cac-436e-b5c8-b0f5d9ca312d"), RecipeId = new Guid("8875f694-4f87-484d-bb2b-413fa5c7c369") },
                        new { IngredientId = new Guid("1f8c120b-a77e-4e91-96fd-ca318f7e192a"), RecipeId = new Guid("8875f694-4f87-484d-bb2b-413fa5c7c369") },
                        new { IngredientId = new Guid("5361e8fc-1779-4642-a31d-9bf1d480f7da"), RecipeId = new Guid("8875f694-4f87-484d-bb2b-413fa5c7c369") },
                        new { IngredientId = new Guid("6435f0e7-55a6-4a74-8211-ee58379dde1a"), RecipeId = new Guid("8875f694-4f87-484d-bb2b-413fa5c7c369") },
                        new { IngredientId = new Guid("1f8c120b-a77e-4e91-96fd-ca318f7e192a"), RecipeId = new Guid("a0a75f4e-a04c-4306-855d-9f06136a7717") },
                        new { IngredientId = new Guid("5361e8fc-1779-4642-a31d-9bf1d480f7da"), RecipeId = new Guid("a0a75f4e-a04c-4306-855d-9f06136a7717") },
                        new { IngredientId = new Guid("2fb3f367-efdb-4186-b164-4836a660e1c4"), RecipeId = new Guid("a0a75f4e-a04c-4306-855d-9f06136a7717") },
                        new { IngredientId = new Guid("5361e8fc-1779-4642-a31d-9bf1d480f7da"), RecipeId = new Guid("501bd33b-92b6-48e6-87ec-0e5d5a2f07e8") },
                        new { IngredientId = new Guid("67847eae-9541-4637-b84d-17128fd292a0"), RecipeId = new Guid("501bd33b-92b6-48e6-87ec-0e5d5a2f07e8") },
                        new { IngredientId = new Guid("6435f0e7-55a6-4a74-8211-ee58379dde1a"), RecipeId = new Guid("501bd33b-92b6-48e6-87ec-0e5d5a2f07e8") },
                        new { IngredientId = new Guid("c50f4d0a-6cac-436e-b5c8-b0f5d9ca312d"), RecipeId = new Guid("267a56e4-1342-4cec-973e-74f84909b110") },
                        new { IngredientId = new Guid("5361e8fc-1779-4642-a31d-9bf1d480f7da"), RecipeId = new Guid("267a56e4-1342-4cec-973e-74f84909b110") },
                        new { IngredientId = new Guid("6435f0e7-55a6-4a74-8211-ee58379dde1a"), RecipeId = new Guid("267a56e4-1342-4cec-973e-74f84909b110") },
                        new { IngredientId = new Guid("dbd5ec8e-5b4a-4263-a69f-a48b67fa5d98"), RecipeId = new Guid("267a56e4-1342-4cec-973e-74f84909b110") },
                        new { IngredientId = new Guid("c50f4d0a-6cac-436e-b5c8-b0f5d9ca312d"), RecipeId = new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e") },
                        new { IngredientId = new Guid("1f8c120b-a77e-4e91-96fd-ca318f7e192a"), RecipeId = new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e") },
                        new { IngredientId = new Guid("0e3ec007-3546-4e01-afd1-1c153c0ce93b"), RecipeId = new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e") },
                        new { IngredientId = new Guid("eaa1f9f4-67cd-4dfc-8557-42dfa017b6ba"), RecipeId = new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e") }
                    );
                });

            modelBuilder.Entity("Pizzeria.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new { Id = new Guid("5127599a-e956-4f5e-9385-1b8c6a74e4f1"), RoleName = "Customer" },
                        new { Id = new Guid("8634c476-20fa-4391-b8f7-8713abf61af0"), RoleName = "Admin" }
                    );
                });

            modelBuilder.Entity("Pizzeria.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("DepositedCash");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired();

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = new Guid("3b86f5a2-1978-46e3-a0b6-edbb6b558efc"), DepositedCash = 10000m, Email = "john@doe.com", FirstName = "John", LastName = "Doe", PasswordHash = new byte[] { 54, 7, 163, 253, 40, 189, 226, 20, 245, 209, 159, 19, 50, 239, 18, 79, 77, 69, 127, 132, 188, 129, 50, 128, 31, 159, 211, 207, 126, 207, 255, 151, 33, 66, 165, 203, 171, 22, 64, 105, 88, 171, 204, 253, 189, 177, 13, 188, 152, 198, 147, 167, 68, 180, 92, 178, 94, 33, 180, 27, 27, 206, 125, 243 }, PasswordSalt = new byte[] { 71, 80, 83, 81, 90, 82, 72, 57, 69, 84, 48, 72, 83, 90, 79, 69, 74, 50, 55, 85, 86, 71, 85, 69, 65, 48, 71, 83, 90, 85, 76, 56, 50, 78, 68, 78, 53, 85, 82, 89, 82, 88, 80, 49, 87, 89, 48, 48, 52, 69, 80, 84, 65, 51, 75, 56, 68, 74, 90, 70, 86, 50, 69, 70, 86, 51, 65, 56, 86, 68, 65, 70, 56, 88, 88, 65, 76, 85, 69, 86, 89, 49, 65, 50, 71, 73, 53, 50, 48, 65, 55, 79, 75, 73, 83, 83, 79, 55, 80, 66, 65, 72, 79, 83, 57, 66, 69, 51, 74, 90, 52, 80, 81, 80, 70, 55, 57, 84, 82, 90, 49, 87, 70, 86, 86, 86, 53, 76 }, RoleId = new Guid("5127599a-e956-4f5e-9385-1b8c6a74e4f1") },
                        new { Id = new Guid("c643b944-53d9-4a0c-9922-3486558b9129"), DepositedCash = 10000m, Email = "admin@admin.com", FirstName = "Admin", LastName = "Admin", PasswordHash = new byte[] { 54, 7, 163, 253, 40, 189, 226, 20, 245, 209, 159, 19, 50, 239, 18, 79, 77, 69, 127, 132, 188, 129, 50, 128, 31, 159, 211, 207, 126, 207, 255, 151, 33, 66, 165, 203, 171, 22, 64, 105, 88, 171, 204, 253, 189, 177, 13, 188, 152, 198, 147, 167, 68, 180, 92, 178, 94, 33, 180, 27, 27, 206, 125, 243 }, PasswordSalt = new byte[] { 71, 80, 83, 81, 90, 82, 72, 57, 69, 84, 48, 72, 83, 90, 79, 69, 74, 50, 55, 85, 86, 71, 85, 69, 65, 48, 71, 83, 90, 85, 76, 56, 50, 78, 68, 78, 53, 85, 82, 89, 82, 88, 80, 49, 87, 89, 48, 48, 52, 69, 80, 84, 65, 51, 75, 56, 68, 74, 90, 70, 86, 50, 69, 70, 86, 51, 65, 56, 86, 68, 65, 70, 56, 88, 88, 65, 76, 85, 69, 86, 89, 49, 65, 50, 71, 73, 53, 50, 48, 65, 55, 79, 75, 73, 83, 83, 79, 55, 80, 66, 65, 72, 79, 83, 57, 66, 69, 51, 74, 90, 52, 80, 81, 80, 70, 55, 57, 84, 82, 90, 49, 87, 70, 86, 86, 86, 53, 76 }, RoleId = new Guid("8634c476-20fa-4391-b8f7-8713abf61af0") }
                    );
                });

            modelBuilder.Entity("Pizzeria.Models.Order", b =>
                {
                    b.HasOne("Pizzeria.Models.Caterer", "Caterer")
                        .WithMany()
                        .HasForeignKey("CatererId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Pizzeria.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Pizzeria.Models.OrderAdditive", b =>
                {
                    b.HasOne("Pizzeria.Models.Additive", "Additive")
                        .WithMany("OrderAdditives")
                        .HasForeignKey("AdditiveId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Pizzeria.Models.Order", "Order")
                        .WithMany("OrderAdditives")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Pizzeria.Models.OrderHistory", b =>
                {
                    b.HasOne("Pizzeria.Models.Order", "Order")
                        .WithOne("OrderHistory")
                        .HasForeignKey("Pizzeria.Models.OrderHistory", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Pizzeria.Models.Recipe", b =>
                {
                    b.HasOne("Pizzeria.Models.Order")
                        .WithMany("Recipes")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Pizzeria.Models.RecipeIngredient", b =>
                {
                    b.HasOne("Pizzeria.Models.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Pizzeria.Models.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Pizzeria.Models.User", b =>
                {
                    b.HasOne("Pizzeria.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

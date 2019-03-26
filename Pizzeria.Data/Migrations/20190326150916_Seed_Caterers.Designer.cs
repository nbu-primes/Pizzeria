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
    [Migration("20190326150916_Seed_Caterers")]
    partial class Seed_Caterers
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

                    b.Property<int>("Price");

                    b.HasKey("Id");

                    b.ToTable("Additives");
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
                        new { Id = new Guid("eb372a85-ff19-48a2-97de-2d888b664e93"), Name = "Mushrooms", Price = 2m }
                    );
                });

            modelBuilder.Entity("Pizzeria.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<Guid>("CatererId");

                    b.Property<Guid>("OrderHistoryId");

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

                    b.HasKey("OrderId", "AdditiveId");

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

                    b.Property<Guid?>("OrderId");

                    b.Property<double>("Price");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new { Id = new Guid("f7453db5-628d-450f-97ce-ca1a5a1b9f0d"), Description = "Pepperoni", ImagePath = "https://www.silviocicchi.com/pizzachef/wp-content/uploads/2015/02/p-evid1-672x372.jpg", IsTemplate = true, Price = 13.5, Weight = 1500.0 },
                        new { Id = new Guid("62326247-6562-4584-83da-225b000376a6"), Description = "Mushroom pizza", ImagePath = "https://d2814mmsvlryp1.cloudfront.net/wp-content/uploads/2017/03/WGC-mushroom-sheet-pan-pizza-1-copy-2.jpg", IsTemplate = true, Price = 11.99, Weight = 1300.0 }
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
                        new { IngredientId = new Guid("eb372a85-ff19-48a2-97de-2d888b664e93"), RecipeId = new Guid("62326247-6562-4584-83da-225b000376a6") }
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

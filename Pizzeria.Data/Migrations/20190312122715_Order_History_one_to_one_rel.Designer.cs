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
    [Migration("20190312122715_Order_History_one_to_one_rel")]
    partial class Order_History_one_to_one_rel
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

                    b.Property<int>("Count");

                    b.Property<string>("Name")
                        .IsRequired();

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
                });

            modelBuilder.Entity("Pizzeria.Models.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
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
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<Guid?>("OrderId");

                    b.Property<double>("Price");

                    b.Property<double>("Weight");

                    b.HasKey("Key");

                    b.HasIndex("OrderId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Pizzeria.Models.RecipeIngredient", b =>
                {
                    b.Property<Guid>("IngredientId");

                    b.Property<Guid>("RecipeId");

                    b.HasKey("IngredientId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("Pizzeria.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Pizzeria.Models.Users", b =>
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

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Pizzeria.Models.Order", b =>
                {
                    b.HasOne("Pizzeria.Models.Caterer", "Caterer")
                        .WithMany()
                        .HasForeignKey("CatererId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Pizzeria.Models.Users", "User")
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

            modelBuilder.Entity("Pizzeria.Models.Users", b =>
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

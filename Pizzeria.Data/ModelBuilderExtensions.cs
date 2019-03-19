using Microsoft.EntityFrameworkCore;
using Pizzeria.Models;
using Pizzeria.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedRecipes(this ModelBuilder modelBuilder)
        {
            var recipes = new[]
            {
                 new Recipe
                    {
                        Id = new Guid("f7453db5-628d-450f-97ce-ca1a5a1b9f0d"),
                        Description = "Pepperoni",
                        Price = 13.50d,
                        Weight = 1500,
                        ImagePath = "https://www.silviocicchi.com/pizzachef/wp-content/uploads/2015/02/p-evid1-672x372.jpg",
                        IsTemplate = true
                    },
                 new Recipe
                 {
                     Id = new Guid("62326247-6562-4584-83da-225b000376a6"),
                     Description = "Mushroom pizza",
                     Price = 11.99d,
                     Weight = 1300,
                     ImagePath = "https://d2814mmsvlryp1.cloudfront.net/wp-content/uploads/2017/03/WGC-mushroom-sheet-pan-pizza-1-copy-2.jpg",
                     IsTemplate = true
                 }
            };

            var ingredients = new[]
            {
                new Ingredient
                {
                    Id = new Guid("4822d030-b2da-4fdb-85e6-4559c2029eac"),
                    Name = "Salami",
                    Price = 5
                },
                new Ingredient
                {
                    Id = new Guid("c50f4d0a-6cac-436e-b5c8-b0f5d9ca312d"),
                    Name = "Tomato sauce",
                    Price = 2
                },
                new Ingredient
                {
                    Id = new Guid("ab8e13dc-a412-4959-b626-786105564735"),
                    Name = "Cheese",
                    Price = 2
                },
                new Ingredient
                {
                    Id = new Guid("eb372a85-ff19-48a2-97de-2d888b664e93"),
                    Name = "Mushrooms",
                    Price = 2
                }
            };

            var recipeIngredients = new[]
            {
                new RecipeIngredient(){RecipeId = recipes[0].Id, IngredientId = ingredients[0].Id},
                new RecipeIngredient(){RecipeId = recipes[0].Id, IngredientId = ingredients[1].Id},
                new RecipeIngredient(){RecipeId = recipes[1].Id, IngredientId = ingredients[2].Id},
                new RecipeIngredient(){RecipeId = recipes[1].Id, IngredientId = ingredients[3].Id},
            };

            modelBuilder.Entity<Recipe>()
                .HasData(recipes);

            modelBuilder.Entity<Ingredient>()
                .HasData(ingredients);

            modelBuilder.Entity<RecipeIngredient>()
                .HasData(recipeIngredients);
        }
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            var roles = new[]
            {
                new Role
                {
                    Id = new Guid("5127599a-e956-4f5e-9385-1b8c6a74e4f1"),
                    RoleName = "Customer"
                },
                new Role
                {
                    Id = new Guid("8634c476-20fa-4391-b8f7-8713abf61af0"),
                    RoleName = "Admin"
                }
            };

            // customer password
            byte[] customerPasswordHash = null;
            byte[] customerPasswordSalt = null;
            HashPassword("asd123", out customerPasswordHash, out customerPasswordSalt);

            // admin password
            byte[] adminPasswordHash = null;
            byte[] adminPasswordSalt = null;
            HashPassword("asd123", out adminPasswordHash, out adminPasswordSalt);
            var users = new[]
            {
                new User()
                {
                    Id = new Guid("3b86f5a2-1978-46e3-a0b6-edbb6b558efc"),
                    FirstName = "John",
                    LastName = "Doe",
                    DepositedCash = 10000,
                    Email = "john@doe.com",
                    RoleId = roles[0].Id,
                    PasswordHash = customerPasswordHash,
                    PasswordSalt = customerPasswordSalt
                },
                new User()
                {
                    Id = new Guid("c643b944-53d9-4a0c-9922-3486558b9129"),
                    FirstName = "Admin",
                    LastName = "Admin",
                    DepositedCash = 10000,
                    Email = "admin@admin.com",
                    RoleId = roles[1].Id,
                    PasswordHash = adminPasswordHash,
                    PasswordSalt = adminPasswordSalt
                }
            };

            modelBuilder.Entity<Role>()
                .HasData(roles);

            modelBuilder.Entity<User>()
                .HasData(users);
        }

        private static void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(Encoding.UTF8.GetBytes("GPSQZRH9ET0HSZOEJ27UVGUEA0GSZUL82NDN5URYRXP1WY004EPTA3K8DJZFV2EFV3A8VDAF8XXALUEVY1A2GI520A7OKISSO7PBAHOS9BE3JZ4PQPF79TRZ1WFVVV5L")))
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}

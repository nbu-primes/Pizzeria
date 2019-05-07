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
                        Name = "Pepperoni",
                        Description = "A tasty Pepperoni",
                        Price = 13.50d,
                        Weight = 1500,
                        ImagePath = "https://www.silviocicchi.com/pizzachef/wp-content/uploads/2015/02/p-evid1-672x372.jpg",
                        IsTemplate = true
                    },
                 new Recipe
                 {
                     Id = new Guid("62326247-6562-4584-83da-225b000376a6"),
                     Name="Mushroom pizza",
                     Description = "Pizza with fresh mushrooms",
                     Price = 11.99d,
                     Weight = 1300,
                     ImagePath = "https://d2814mmsvlryp1.cloudfront.net/wp-content/uploads/2017/03/WGC-mushroom-sheet-pan-pizza-1-copy-2.jpg",
                     IsTemplate = true
                 },
                  new Recipe
                 {
                     Id = new Guid("8875f694-4f87-484d-bb2b-413fa5c7c369"),
                     Name="Margherita Pizza",
                     Description = "Sometimes you just can't beat a classic like fresh and simple Margherita Pizza",
                     Price = 9.99d,
                     Weight = 1300,
                     ImagePath = "http://www.fnstatic.co.uk/images/content/recipe/margherita-pizza.jpeg",
                     IsTemplate = true
                 },
                   new Recipe
                 {
                     Id = new Guid("a0a75f4e-a04c-4306-855d-9f06136a7717"),
                     Name="Calzone Pizza",
                     Description = "A calzone is an Italian oven-baked folded pizza that originated in Naples",
                     Price = 13d,
                     Weight = 1300,
                     ImagePath = "http://www.fnstatic.co.uk/images/content/recipe/calzone-pizza.jpg",
                     IsTemplate = true
                 },
                    new Recipe
                 {
                     Id = new Guid("501bd33b-92b6-48e6-87ec-0e5d5a2f07e8"),
                     Name="Bruschetta Pizzaiola",
                     Description = "It is an Italian style snack that is tasty and made it quickly",
                     Price = 8.50d,
                     Weight = 1000,
                     ImagePath = "http://www.fnstatic.co.uk/images/content/recipe/bruschetta-pizzaiola.jpeg",
                     IsTemplate = true
                 },
                new Recipe
                 {
                     Id = new Guid("267a56e4-1342-4cec-973e-74f84909b110"),
                     Name="Pizza Ortolana",
                     Description = "Ortolano in italian means 'from the vegetable patch'. It is a great vegetarian pizza and a somewhat healthier option as it’s made with grilled eggplant, roasted bell pepper and artichoke hearts",
                     Price = 9.99d,
                     Weight = 1000,
                     ImagePath = "https://www.manusmenu.com/wp-content/uploads/2015/08/1-Pizza-Ortolana-4-1-of-1.jpg",
                     IsTemplate = true
                 },
                new Recipe
                 {
                     Id = new Guid("b0b4c120-8f76-4926-b989-1fe6c516b74e"),
                     Name="Blue Cheese Prosciutto Pizza",
                     Description = "Spread bases with pizza sauce and sprinkle with pizza cheese and blue cheese",
                     Price = 12.30d,
                     Weight = 1000,
                     ImagePath = "https://static-communitytable.parade.com/wp-content/uploads/2017/01/IMG_5857-1.jpg",
                     IsTemplate = true
                 },
            };

            var ingredients = new[]
            {
                new Ingredient // 0
                {
                    Id = new Guid("4822d030-b2da-4fdb-85e6-4559c2029eac"),
                    Name = "Salami",
                    Price = 5
                },
                new Ingredient // 1
                {
                    Id = new Guid("c50f4d0a-6cac-436e-b5c8-b0f5d9ca312d"),
                    Name = "Tomato sauce",
                    Price = 2
                },
                new Ingredient // 2
                {
                    Id = new Guid("ab8e13dc-a412-4959-b626-786105564735"),
                    Name = "Cheese",
                    Price = 2
                },
                new Ingredient // 3
                {
                    Id = new Guid("eb372a85-ff19-48a2-97de-2d888b664e93"),
                    Name = "Mushrooms",
                    Price = 2
                },
                new Ingredient // 4
                {
                    Id = new Guid("1f8c120b-a77e-4e91-96fd-ca318f7e192a"),
                    Name = "Garlic",
                    Price = 0.5m
                },
                  new Ingredient // 5
                {
                    Id = new Guid("5361e8fc-1779-4642-a31d-9bf1d480f7da"),
                    Name = "Mozzarella",
                    Price = 1.2m
                },
                new Ingredient // 6
                {
                    Id = new Guid("2fb3f367-efdb-4186-b164-4836a660e1c4"),
                    Name = "Onion",
                    Price = 0.5m
                },
                new Ingredient() // 7
                {
                    Id = new Guid("67847eae-9541-4637-b84d-17128fd292a0"),
                    Name = "Cherry Tomatoes",
                    Price = 1.50m
                },
                new Ingredient() // 8
                {
                    Id = new Guid("6435f0e7-55a6-4a74-8211-ee58379dde1a"),
                    Name = "Fresh Basil",
                    Price = 1
                },
                new Ingredient() // 9
                {
                    Id = new Guid("dbd5ec8e-5b4a-4263-a69f-a48b67fa5d98"),
                    Name = "Fresh Peppers",
                    Price = 1.5m
                },
                new Ingredient() // 10
                {
                    Id = new Guid("0e3ec007-3546-4e01-afd1-1c153c0ce93b"),
                    Name = "Prosciutto Crudo",
                    Price = 2.30m
                },
                new Ingredient() // 11
                {
                    Id = new Guid("eaa1f9f4-67cd-4dfc-8557-42dfa017b6ba"),
                    Name = "Blue Cheese",
                    Price = 1.20m
                }
            };

            var recipeIngredients = new[]
            {
                new RecipeIngredient(){RecipeId = recipes[0].Id, IngredientId = ingredients[0].Id},
                new RecipeIngredient(){RecipeId = recipes[0].Id, IngredientId = ingredients[1].Id},

                new RecipeIngredient(){RecipeId = recipes[1].Id, IngredientId = ingredients[2].Id},
                new RecipeIngredient(){RecipeId = recipes[1].Id, IngredientId = ingredients[3].Id},

                new RecipeIngredient(){RecipeId = recipes[2].Id, IngredientId = ingredients[1].Id},
                new RecipeIngredient(){RecipeId = recipes[2].Id, IngredientId = ingredients[4].Id},
                new RecipeIngredient(){RecipeId = recipes[2].Id, IngredientId = ingredients[5].Id},
                new RecipeIngredient(){RecipeId = recipes[2].Id, IngredientId = ingredients[8].Id},

                new RecipeIngredient(){RecipeId = recipes[3].Id, IngredientId = ingredients[4].Id},
                new RecipeIngredient(){RecipeId = recipes[3].Id, IngredientId = ingredients[5].Id},
                new RecipeIngredient(){RecipeId = recipes[3].Id, IngredientId = ingredients[6].Id},

                new RecipeIngredient(){RecipeId = recipes[4].Id, IngredientId = ingredients[5].Id},
                new RecipeIngredient(){RecipeId = recipes[4].Id, IngredientId = ingredients[7].Id},
                new RecipeIngredient(){RecipeId = recipes[4].Id, IngredientId = ingredients[8].Id},


                new RecipeIngredient(){RecipeId = recipes[5].Id, IngredientId = ingredients[1].Id},
                new RecipeIngredient(){RecipeId = recipes[5].Id, IngredientId = ingredients[5].Id},
                new RecipeIngredient(){RecipeId = recipes[5].Id, IngredientId = ingredients[8].Id},
                new RecipeIngredient(){RecipeId = recipes[5].Id, IngredientId = ingredients[9].Id},

                new RecipeIngredient(){RecipeId = recipes[6].Id, IngredientId = ingredients[1].Id},
                new RecipeIngredient(){RecipeId = recipes[6].Id, IngredientId = ingredients[4].Id},
                new RecipeIngredient(){RecipeId = recipes[6].Id, IngredientId = ingredients[10].Id},
                new RecipeIngredient(){RecipeId = recipes[6].Id, IngredientId = ingredients[11].Id},


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

        public static void SeedCaterers(this ModelBuilder modelBuilder)
        {
            var Caterers = new[]
            {
                new Caterer
                {
                    Id = new Guid("b89ca9ab-ae08-4f34-8369-4397b47702d1"),
                    Name = "Food Panda",
                    IsAvailable = true
                },
                new Caterer
                {
                    Id = new Guid("d6c569f9-0df2-4c6e-967f-68a2684c22da"),
                    Name = "Takeaway",
                    IsAvailable = true
                }
            };

            modelBuilder.Entity<Caterer>()
                .HasData(Caterers);
        }

        public static void SeedAdditives(this ModelBuilder modelBuilder)
        {
            var Additives = new[]
            {
                new Additive
                {
                    Id = new Guid("38de00d4-a8a2-4586-8f39-a00ff5a8ba71"),
                    Name = "Soda",
                    Price = 1
                },
                new Additive
                {
                    Id = new Guid("69152cbc-8c3a-4444-9914-ab95a16b4485"),
                    Name = "Coke",
                    Price = 1
                },
                new Additive
                {
                    Id = new Guid("c11e6a87-11b3-4e64-9c9f-62a019622384"),
                    Name = "French Fries",
                    Price = 2
                },
                new Additive
                {
                    Id = new Guid("1524f795-ad1c-45cc-835a-f971a22735e9"),
                    Name = "Hot Sauce",
                    Price = 1
                },
                new Additive
                {
                    Id = new Guid("9c068dfe-120a-4bc8-8574-68211a277784"),
                    Name = "Barbecue Sauce",
                    Price = 1
                },
                new Additive
                {
                    Id = new Guid("20a5f42a-9585-4d55-a4fb-d73d27b34ffd"),
                    Name = "Brownie",
                    Price = 2
                }
            };

            modelBuilder.Entity<Additive>()
                .HasData(Additives);
        }

    }
}


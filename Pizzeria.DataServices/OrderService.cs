using System;
using System.Collections.Generic;
using System.Linq;
using Pizzeria.Data;
using Pizzeria.DataServices.Contracts;
using Pizzeria.Models;
using Pizzeria.Models.DTO;

namespace Pizzeria.DataServices
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext dbContext;

        public OrderService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public int PlaceOrder(OrderDto orderDto, string userId)
        {

            var order = new Order()
            {
                Address = orderDto.Address,
                Caterer = dbContext.Caterers.FirstOrDefault(x => x.Id == orderDto.CatererId),
                CatererId = orderDto.CatererId,
                TotalPrice = orderDto.TotalPrice,
                User = dbContext.Users.FirstOrDefault(x => x.Email.Equals(userId)),
                
            };

            foreach (var orderAdditive in orderDto.OrderAdditives)
            {
                var newOrderAdditive = new OrderAdditive();
                newOrderAdditive.Additive = dbContext.Additives.FirstOrDefault(x => x.Id == orderAdditive.Id);
                newOrderAdditive.Order = order;
                order.OrderAdditives.Add(newOrderAdditive);
            }
            foreach (var recipe in orderDto.Recipes)
            {
                var newRecipe = dbContext.Recipes.FirstOrDefault(x => x.Id == recipe.Id);
                if (newRecipe == null)
                {
                    newRecipe = new Recipe()
                    {
                        Description = recipe.Description,
                        ImagePath = recipe.ImagePath,
                        IsTemplate = recipe.IsTemplate,
                        Price = recipe.Price,
                        Weight = recipe.Weight
                    };
                    foreach (var ingredient in recipe.Ingredients)
                    {
                        var newRecipeIngredient = new RecipeIngredient();
                        var newIngredient = dbContext.Ingredients.FirstOrDefault(x => x.Id == ingredient.Id);
                        newRecipeIngredient.Ingredient = newIngredient;
                        newRecipeIngredient.Recipe = newRecipe;

                        newRecipe.RecipeIngredients.Add(newRecipeIngredient);
                    }
                    
                    //probably add the recipe if EF does not automatically
                    order.Recipes.Add(newRecipe);
                }
                else
                {
                    order.Recipes.Add(newRecipe);
                }
            }

            var history = new OrderHistory {OrderStarted = DateTime.Now};
            order.OrderHistory = history;

            dbContext.Orders.Add(order);
            return dbContext.SaveChanges();
        }
    }
}
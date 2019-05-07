using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
                Id = Guid.NewGuid(),
                Address = orderDto.Address,
                Caterer = dbContext.Caterers.FirstOrDefault(x => x.Id == orderDto.CatererId),
                TotalPrice = orderDto.TotalPrice,
                User = dbContext.Users.FirstOrDefault(x => x.Email.Equals(userId)),

            };

            foreach (var incomingOrderAddt in orderDto.OrderAdditivesPack)
            {
                var newOrderAdditive = new OrderAdditive();
                newOrderAdditive.Additive = dbContext.Additives
                        .FirstOrDefault(x => x.Id == incomingOrderAddt.Product.Id);
                newOrderAdditive.Order = order;
                newOrderAdditive.Count = incomingOrderAddt.Quantity;
                order.OrderAdditives.Add(newOrderAdditive);
            }
            foreach (var recipe in orderDto.Recipes)
            {
                /*
                     If the recipe is not a template (aka modified) it should be created as a new one
		              - therefore assign it with a new ID
                 */
                Guid modifiedRecipeId = new Guid();
                if (!recipe.IsTemplate)
                {
                    modifiedRecipeId = Guid.NewGuid();
                    recipe.Id = modifiedRecipeId;
                }
                var newRecipe = dbContext.Recipes.FirstOrDefault(x => x.Id == recipe.Id);
                if (newRecipe == null)
                {
                    newRecipe = new Recipe()
                    {
                        Id = modifiedRecipeId,
                        Description = recipe.Description,
                        ImagePath = recipe.ImagePath,
                        IsTemplate = recipe.IsTemplate,
                        Price = recipe.Price,
                        Weight = recipe.Weight,
                        Name = recipe.Name
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

            var history = new OrderHistory
            {
                Id = Guid.NewGuid(),
                OrderStarted = DateTime.Now
            };
            order.OrderHistory = history;

            dbContext.Orders.Add(order);
            return dbContext.SaveChanges();
        }

        public IEnumerable<UserOrderHistoryDto> UserOrders(Guid userId)
        {
            var orders = this.dbContext.Orders.Where(o => o.UserId == userId)
                                .Include(x => x.OrderAdditives)
                                .OrderBy(o => o.OrderHistory.OrderStarted)
                                .Select(o => new UserOrderHistoryDto()
                                {
                                    OrderId = o.Id,
                                    OrderedAt = o.OrderHistory.OrderStarted,
                                    Price = o.TotalPrice,
                                    Caterer = o.Caterer.Name,
                                    Additives = o.OrderAdditives.Select(oa => new UserOrderAdditive()
                                    {
                                        Name = oa.Additive.Name,
                                        Price = oa.Additive.Price,
                                        Count = oa.Count
                                    }).ToList(),
                                    Recipes = o.Recipes.Select(r => new RecipeDto()
                                    {
                                        Name = r.Name,
                                        Description = r.Description,
                                        Price = r.Price,
                                        Ingredients = r.RecipeIngredients.Select(ri => new IngredientDto()
                                        {
                                            Name = ri.Ingredient.Name
                                        }).ToList()
                                    }).ToList()
                                })
                                .ToList();

            return orders;

        }
    }
}

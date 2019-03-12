﻿using Microsoft.EntityFrameworkCore;
using Pizzeria.Data;
using Pizzeria.DataServices.Contracts;
using Pizzeria.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzeria.DataServices
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext dbContext;

        public RecipeService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException("dbContext");
        }

        public IEnumerable<RecipeDto> GetTemplateRecipes()
        {
            var templateRecipes = this.dbContext.Recipes
                .Where(r => r.IsTemplate == true)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .Select(r => new RecipeDto(r))
                .ToList();

            return templateRecipes;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Pizzeria.DataServices.Contracts;
using Pizzeria.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.Api.Controllers
{
    [Route("api/recipe")]
    public class RecipeController
    {
        private readonly IRecipeService recipeService;
        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService ?? throw new ArgumentNullException("recipeService");
        }

        [HttpGet]
        public IEnumerable<RecipeDto> GetTemplateRecipes()
        {
            return this.recipeService.GetTemplateRecipes();
        }
    }
}

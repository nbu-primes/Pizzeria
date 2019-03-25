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
    [ApiController]
    public class RecipeController : ControllerBase
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
        
        [HttpGet("{id:guid}")]
        public RecipeDto GetRecipe(Guid id)
        {
            return this.recipeService.GetRecipe(id);
        }

        [HttpGet("~/api/ingredient")]
        public IEnumerable<IngredientDto> GetAllIngredients()
        {
            return this.recipeService.GetAllIngredients();
        }
    }
}

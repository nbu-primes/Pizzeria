using Pizzeria.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.DataServices.Contracts
{
    public interface IRecipeService
    {
        IEnumerable<RecipeDto> GetTemplateRecipes();
        RecipeDto GetRecipe(Guid id);
        IEnumerable<IngredientDto> GetAllIngredients();
    }
}

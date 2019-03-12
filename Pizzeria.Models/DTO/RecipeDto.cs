using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzeria.Models.DTO
{
    public class RecipeDto
    {
        public RecipeDto(Recipe r)
        {
            this.Id = r.Id;
            this.Description = r.Description;
            this.ImageUrl = r.ImageUrl;
            this.Price = r.Price;
            this.Weight = r.Weight;
            this.IsTemplate = r.IsTemplate;
            this.Ingredients = r.RecipeIngredients
                .Select(ri => new IngredientDto(ri.Ingredient.Name, ri.Ingredient.Price));
        }

        public Guid Id { get; set; }
        
        public string Description { get; set; }

        public IEnumerable<IngredientDto> Ingredients { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public double Weight { get; set; }

        public bool IsTemplate { get; set; }
    }
}

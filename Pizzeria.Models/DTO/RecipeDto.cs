using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzeria.Models.DTO
{
    public class RecipeDto
    {
        public RecipeDto()
        {
            
        }
        public RecipeDto(Recipe r)
        {
            this.Id = r.Id;
            this.Name = r.Name;
            this.Description = r.Description;
            this.ImagePath = r.ImagePath;
            this.Price = r.Price;
            this.Weight = r.Weight;
            this.IsTemplate = r.IsTemplate;
            this.Ingredients = r.RecipeIngredients
                .Select(ri => new IngredientDto(ri.Ingredient));
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<IngredientDto> Ingredients { get; set; }

        public string ImagePath { get; set; }

        public double Price { get; set; }

        public double Weight { get; set; }

        public bool IsTemplate { get; set; }
    }
}

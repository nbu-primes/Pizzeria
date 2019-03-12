using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Models
{
    public class RecipeIngredient
    {
        public Recipe Recipe { get; set; }
        public Guid RecipeId { get; set; }

        public Ingredient Ingredient { get; set; }
        public Guid IngredientId { get; set; }
    }
}

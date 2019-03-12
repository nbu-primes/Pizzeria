using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pizzeria.Models
{
    public class Ingredient
    {
        private ICollection<RecipeIngredient> recipeIngredients;

        public Ingredient()
        {
            this.recipeIngredients = new HashSet<RecipeIngredient>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }


        public ICollection<RecipeIngredient> RecipeIngredients
        { get => this.recipeIngredients; set => this.recipeIngredients = value; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Pizzeria.Models
{
    public class Recipe
    {
        private ICollection<RecipeIngredient> recipeIngredients;
        public Recipe()
        {
            this.recipeIngredients = new HashSet<RecipeIngredient>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients
        {
            get => this.recipeIngredients; set => this.recipeIngredients = value;
        }

        [Required]
        public string ImagePath { get; set; }

        public double Price { get; set; }

        public double Weight { get; set; }

        public bool IsTemplate { get; set; }
    }
}

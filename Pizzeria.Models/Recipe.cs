﻿using System;
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
        public Guid Key { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients
        {
            get => this.recipeIngredients; set => this.recipeIngredients = value;
        }

        [Required]
        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public double Weight { get; set; }
    }
}

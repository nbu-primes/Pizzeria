using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Models.DTO
{
    public class IngredientDto
    {
        public IngredientDto(Ingredient i)
        {
            this.Name = i.Name;
            this.Price = i.Price;
            this.Id = i.Id;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

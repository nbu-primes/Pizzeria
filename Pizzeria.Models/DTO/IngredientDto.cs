using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Models.DTO
{
    public class IngredientDto
    {
        public IngredientDto(string name, decimal price)
        {
            this.Name = name ?? throw new ArgumentNullException("name");
            this.Price = price;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

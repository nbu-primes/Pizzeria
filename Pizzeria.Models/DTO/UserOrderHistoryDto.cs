using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Models.DTO
{
    public class UserOrderHistoryDto
    {
        public Guid OrderId { get; set; }
        public DateTime OrderedAt { get; set; }
        public decimal Price { get; set; }
        public string Caterer { get; set; }
        public List<RecipeDto> Recipes { get; set; }
        public List<UserOrderAdditive> Additives { get; set; }
        
    }

    public class UserOrderAdditive
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}

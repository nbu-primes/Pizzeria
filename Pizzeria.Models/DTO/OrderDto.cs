using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Pizzeria.Models.DTO
{
    public class OrderDto
    {
        public OrderDto()
        {
        }

        public Guid Id { get; set; }

        public string Address { get; set; }
        
        public IEnumerable<AdditivePackDto> OrderAdditivesPack { get; set; }

        public IEnumerable<RecipeDto> Recipes { get; set; }

        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; }
        public Guid CatererId { get; set; }
    }
}
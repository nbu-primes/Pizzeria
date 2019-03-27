using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Pizzeria.Models.DTO
{
    public class OrderDto
    {
        public OrderDto(Order o)
        {
            this.Id = o.Id;
            this.Address = o.Address;
            this.Recipes = o.Recipes
                .Select(ri => new RecipeDto(ri));
            this.OrderAdditives = o.OrderAdditives
                .Select(x => new AdditiveDto(x.Additive));
            this.TotalPrice = o.TotalPrice;
            this.UserId = o.UserId;
            this.CatererId = o.CatererId;
        }

        public Guid Id { get; set; }

        public string Address { get; set; }

        public IEnumerable<AdditiveDto> OrderAdditives { get; set; }

        public IEnumerable<RecipeDto> Recipes { get; set; }

        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; }
        public Guid CatererId { get; set; }
    }
}
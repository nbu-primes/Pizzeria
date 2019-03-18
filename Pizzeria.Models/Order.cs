using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pizzeria.Models
{
    public class Order
    {
        private ICollection<OrderAdditive> orderAdditives;
        private ICollection<Recipe> foodItems;

        public Order()
        {
            this.orderAdditives = new HashSet<OrderAdditive>();
            this.foodItems = new HashSet<Recipe>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(10)]
        public string Address { get; set; }

        public ICollection<OrderAdditive> OrderAdditives
        {
            get => this.orderAdditives; set => this.orderAdditives = value;
        }

        public ICollection<Recipe> Recipes
        {
            get => this.foodItems; set => this.foodItems = value;
        }

        public decimal TotalPrice { get; set; }

        public OrderHistory OrderHistory { get; set; }
        public Guid OrderHistoryId { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }

        public Caterer Caterer { get; set; }
        public Guid CatererId { get; set; }
    }
}

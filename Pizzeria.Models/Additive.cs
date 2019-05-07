using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pizzeria.Models
{
    public class Additive
    {
        private ICollection<OrderAdditive> orderAdditives;

        public Additive()
        {
            this.orderAdditives = new HashSet<OrderAdditive>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        public ICollection<OrderAdditive> OrderAdditives { get => this.orderAdditives; set => this.orderAdditives = value; }
    }
}

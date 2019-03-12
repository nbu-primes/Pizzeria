using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pizzeria.Models
{
    public class OrderHistory
    {
        [Key]
        public Guid Id { get; set; }

        public Order Order { get; set; }
        public Guid OrderId { get; set; }

        public DateTime OrderStarted { get; set; }

        public DateTime? OrderCompleted { get; set; }

    }
}

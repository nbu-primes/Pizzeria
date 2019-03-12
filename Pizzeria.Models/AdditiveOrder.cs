using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Models
{
    public class OrderAdditive
    {

        public Order Order { get; set; }
        public Guid OrderId { get; set; }

        public Additive Additive { get; set; }
        public Guid AdditiveId { get; set; }
    }
}

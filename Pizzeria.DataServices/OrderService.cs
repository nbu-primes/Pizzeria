using System;
using Pizzeria.DataServices.Contracts;
using Pizzeria.Models.DTO;

namespace Pizzeria.DataServices
{
    public class OrderService : IOrderService
    {
        public Guid PlaceOrder(OrderDto order)
        {
            //TODO: Order Processing

            //TODO: Order History
            return Guid.NewGuid();
        }
    }
}
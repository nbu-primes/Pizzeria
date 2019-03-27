using System;
using Pizzeria.Models.DTO;

namespace Pizzeria.DataServices.Contracts
{
    public interface IOrderService
    {
        Guid PlaceOrder(OrderDto order);
    }
}
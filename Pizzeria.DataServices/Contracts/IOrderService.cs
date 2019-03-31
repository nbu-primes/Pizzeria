using System;
using Pizzeria.Models.DTO;

namespace Pizzeria.DataServices.Contracts
{
    public interface IOrderService
    {
        int PlaceOrder(OrderDto order, string userId);
    }
}
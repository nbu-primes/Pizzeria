using System;
using System.Collections.Generic;
using Pizzeria.Models.DTO;

namespace Pizzeria.DataServices.Contracts
{
    public interface IOrderService
    {
        int PlaceOrder(OrderDto order, string userId);
        IEnumerable<UserOrderHistoryDto> UserOrders(Guid userId);
    }
}
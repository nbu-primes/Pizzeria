using System;

namespace Pizzeria.Models.DTO
{
    public class OrderHistoryDto
    {
        public OrderHistoryDto(OrderHistory h)
        {
            this.Id = h.Id;
            this.OrderId = h.OrderId;
            this.OrderStarted = h.OrderStarted;
            this.OrderCompleted = h.OrderCompleted;
        }

        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public DateTime OrderStarted { get; set; }

        public DateTime? OrderCompleted { get; set; }
    }
}
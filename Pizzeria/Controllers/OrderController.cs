﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.DataServices.Contracts;
using Pizzeria.Models.DTO;

namespace Pizzeria.Api.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpPost]
        public IActionResult PlaceOrder([FromBody]OrderDto order)
        {
            var user = this.User.Claims.FirstOrDefault(x =>x.Type == "Email")?.Value;
            var id = orderService.PlaceOrder(order, user);
            return Ok(id);
        }
    }
}
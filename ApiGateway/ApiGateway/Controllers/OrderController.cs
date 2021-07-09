using DataAccess.Interfaces;
using DataAccess.Models.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBasketRepository basketRepository;
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository,IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        [Route("{basketId}")]
        public async Task<Order> createOrderFromBasket(String basketId)
        {
            return await orderRepository.getOrder(basketId);
        }
    }
}

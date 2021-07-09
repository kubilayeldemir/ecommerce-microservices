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
        [Route("{orderId}")]
        public async Task<Order> getOrder(String orderId)
        {
            return await orderRepository.getOrder(orderId);
        }

        [HttpPost]
        public async Task<Order> createOrderFromBasket([FromBody] OrderCreateRequest req)
        {
            var basketProducts = await basketRepository.GetBasket(req.basketId);
            Order order = new Order();
            order.owner = req.owner;
            order.productList = OrderProductMapper.MapOrderProductsList(basketProducts);
            var createdOrder = await orderRepository.createOrder(order);
            if (createdOrder.productList != null)
            {
                await basketRepository.DeleteBasket(req.basketId);
            }
            return createdOrder;
        }
    }
}

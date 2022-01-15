using Clients.Interfaces;
using Clients.Models.Order;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository, IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        [Route("{orderId}")]
        public async Task<Order> GetOrder(string orderId)
        {
            return await _orderRepository.GetOrder(orderId);
        }

        [HttpPost]
        public async Task<Order> CreateOrderFromBasket([FromBody] OrderCreateRequest req)
        {
            var basketProducts = await _basketRepository.GetBasket(req.basketId);
            var order = new Order();
            order.owner = req.owner;
            order.productList = OrderProductMapper.MapOrderProductsList(basketProducts);
            var createdOrder = await _orderRepository.CreateOrder(order);
            if (createdOrder.productList != null)
            {
                await _basketRepository.DeleteBasket(req.basketId);
            }

            return createdOrder;
        }
    }
}
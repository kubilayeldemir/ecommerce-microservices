using Clients.Interfaces;
using Clients.Models.Order;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<IActionResult> GetOrder(string orderId)
        {
            var order = await _orderRepository.GetOrder(orderId);
            return Ok(order);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetOrdersOfUser()
        {
            //TODO add this ep to order service
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderFromBasket([FromBody] OrderCreateRequest req)
        {
            var basketProducts = await _basketRepository.GetBasket(req.basketId);
            var order = new Order();
            order.owner = req.owner;
            //order.owner.Id = HttpContext.User.Claims.First(x => x.Type == "id").Value;
            order.productList = OrderProductMapper.MapOrderProductsList(basketProducts);
            var createdOrder = await _orderRepository.CreateOrder(order);
            if (createdOrder.productList != null)
            {
                await _basketRepository.DeleteBasket(req.basketId);
            }

            return Ok(createdOrder);
        }
    }
}
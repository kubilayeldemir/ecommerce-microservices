using Clients.Interfaces;
using Clients.Models.Basket;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IBasketRepository _basketRepository;


        public BasketController(IProductRepository productRepository, IBasketRepository basketRepository)
        {
            _productRepository = productRepository;
            _basketRepository = basketRepository;
        }

        [HttpGet]
        [Route("{basketId}")]
        public async Task<IActionResult> GetBasketById(string basketId)
        {
            var basketResponse = new BasketPostResponse();
            basketResponse.products = await _basketRepository.GetBasket(basketId);
            basketResponse.basketId = basketId;
            return Ok(basketResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasketOrAddToBasket([FromBody] BasketPostRequest req)
        {
            var realProducts = await _productRepository.GetProductsByIdList(req.products);
            var basketResponse = new BasketPostResponse();

            if (string.IsNullOrEmpty(req.basketId))
            {
                var basketId = await _basketRepository.CreateBasket(realProducts);
                var productsInBasket = await _basketRepository.GetBasket(basketId);
                basketResponse.basketId = basketId;
                basketResponse.products = productsInBasket;
            }
            else
            {
                var newBasket = await _basketRepository.AddToBasket(req.basketId, realProducts);
                basketResponse.basketId = req.basketId;
                basketResponse.products = newBasket;
            }
            return Accepted(basketResponse);
        }
    }
}
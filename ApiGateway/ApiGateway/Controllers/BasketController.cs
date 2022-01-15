using Clients.Interfaces;
using Clients.Models.Basket;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IBasketRepository basketRepository;


        public BasketController(IProductRepository productRepository, IBasketRepository basketRepository)
        {
            this.productRepository = productRepository;
            this.basketRepository = basketRepository;
        }

        [HttpGet]
        [Route("{basketId}")]
        public async Task<BasketPostResponse> GetBasketById(string basketId)
        {
            var basketResponse = new BasketPostResponse();
            basketResponse.products = await basketRepository.GetBasket(basketId);
            basketResponse.basketId = basketId;
            return basketResponse;
        }

        [HttpPost]
        public async Task<BasketPostResponse> CreateBasketOrAddToBasket([FromBody] BasketPostRequest req)
        {
            var realProducts = await productRepository.GetProductsByIdList(req.products);
            var basketResponse = new BasketPostResponse();

            if (String.IsNullOrEmpty(req.basketId))
            {
                String basketId = await basketRepository.CreateBasket(realProducts);
                var productsInBasket = await basketRepository.GetBasket(basketId);
                basketResponse.basketId = basketId;
                basketResponse.products = productsInBasket;
            }
            else
            {
                var newBasket = await basketRepository.AddToBasket(req.basketId, realProducts);
                basketResponse.basketId = req.basketId;
                basketResponse.products = newBasket;
            }
            return basketResponse;
        }
    }
}

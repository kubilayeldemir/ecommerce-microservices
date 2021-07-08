using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Models.Basket;
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
        public async Task<List<Product>> GetBasketById(string basketId)
        {
            return await basketRepository.GetBasket(basketId);
        }

        [HttpPost]
        public async Task<BasketPostResponse> CreateBasketOrAddToBasket([FromBody] BasketPostRequest req)
        {
            if (req.basketId == null)
            {
                var products = await productRepository.GetProductsByIdList(req.products);
                String basketId = await basketRepository.CreateBasket(products);
                var productsInBasket = await basketRepository.GetBasket(basketId);
                var basketResponse = new BasketPostResponse();
                basketResponse.basketId = basketId;
                basketResponse.products = productsInBasket;
                return basketResponse;
            }
            return null;
        }
    }
}

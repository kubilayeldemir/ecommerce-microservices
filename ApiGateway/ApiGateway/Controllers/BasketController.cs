using DataAccess.Interfaces;
using DataAccess.Models;
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


        public BasketController(IProductRepository productRepository,IBasketRepository basketRepository)
        {
            this.productRepository = productRepository;
            this.basketRepository = basketRepository;
        }

        [HttpGet]
        [Route("{basketId}")]
        public async Task<List<Product>> GetProductById(string basketId)
        {
            return await basketRepository.getBasket(basketId);
        }
    }
}

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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<Product> GetProductById(string productId)
        {
            return await productRepository.GetProductById(productId);
        }

        [HttpGet]
        [Route("paged")]
        public async Task<PagedProducts> GetProductsPaged(
            [FromQuery] string brand,
            [FromQuery] int page,
            [FromQuery] int size)
        {
            return await productRepository.GetProductsPaged(brand,page,size);
        }
    }
}

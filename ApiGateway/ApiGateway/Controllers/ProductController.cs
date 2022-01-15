using Clients.Interfaces;
using Clients.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<Product> GetProductById(string productId)
        {
            return await _productRepository.GetProductById(productId);
        }

        [HttpGet]
        [Route("paged")]
        public async Task<PagedProducts> GetProductsPaged(
            [FromQuery] string brand,
            [FromQuery] int page,
            [FromQuery] int size)
        {
            return await _productRepository.GetProductsPaged(brand, page, size);
        }
    }
}
using Clients.Interfaces;
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
        public async Task<IActionResult> GetProductById(string productId)
        {
            var product = await _productRepository.GetProductById(productId);
            return Ok(product);
        }

        [HttpGet]
        [Route("paged")]
        public async Task<IActionResult> GetProductsPaged(
            [FromQuery] string brand,
            [FromQuery] int page,
            [FromQuery] int size)
        {
            var pagedProducts = await _productRepository.GetProductsPaged(brand, page, size);
            return Ok(pagedProducts);
        }
    }
}
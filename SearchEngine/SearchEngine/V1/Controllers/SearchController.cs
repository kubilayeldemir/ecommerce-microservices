using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SearchEngine.Services;

namespace SearchEngine.V1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IProductService _productService;

        public SearchController(ILogger<SearchController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        
        [HttpGet("/q/{query}")]
        public IActionResult Get([FromRoute] string query)
        {
            _logger.LogInformation($"Search query:{query}");
            return Ok();
        }
    }
}
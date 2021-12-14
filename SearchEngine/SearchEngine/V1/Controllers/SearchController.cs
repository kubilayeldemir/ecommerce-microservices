using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SearchEngine.Services;
using SearchEngine.V1.Models.RequestModels;

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
        public async Task<IActionResult> Query([FromRoute] string query, [FromQuery] int size, [FromQuery] int @from)
        {
            _logger.LogInformation($"Search query:{query}");
            var result = await _productService.QueryCombineFields(query, @from, size);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Query([FromQuery] GetProductRequestModel model)
        {
            var products = await _productService.Get(model, model.From, model.Size == 0 ? 10: model.Size);
            return Ok(products);
        }
    }
}
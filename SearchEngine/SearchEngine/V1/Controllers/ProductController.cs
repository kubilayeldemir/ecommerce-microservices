using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SearchEngine.Models;
using SearchEngine.Services;
using SearchEngine.V1.Models.RequestModels;

namespace SearchEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        
        [HttpPost()]
        public async Task<IActionResult> Save([FromBody] ProductRequestModel model)
        {
            var id = await _productService.SaveProduct(model.ToModel());
            return Ok(id);
        }

        [HttpPost("/bulk")]
        public IActionResult BulksSave([FromBody] List<ProductRequestModel> model)
        {
            _logger.LogInformation("Bulk saving...");
            return Accepted(model);
        }
    }
}
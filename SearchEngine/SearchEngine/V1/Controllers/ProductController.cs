using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SearchEngine.Services;
using SearchEngine.V1.Models.RequestModels;

namespace SearchEngine.V1.Controllers
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
        public async Task<IActionResult> BulksSave([FromBody] List<ProductRequestModel> model)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await _productService.BulkSaveProduct(model.Select(x => x.ToModel()).ToList());
            stopwatch.Stop();
            _logger.LogInformation($"Bulk saved {model.Count}, Took:{stopwatch.Elapsed}");
            
            return Accepted(model);
        }
    }
}
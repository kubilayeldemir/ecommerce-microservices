using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SearchEngine.V1.Models.RequestModels;

namespace SearchEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpPost("/bulk")]
        public IActionResult BulksSave([FromBody] List<ProductRequestModel> model)
        {
            _logger.LogInformation("Bulk saving...");
            return Accepted(model);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SearchEngine.V1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;

        public SearchController(ILogger<SearchController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet("/q/{query}")]
        public IActionResult Get([FromRoute] string query)
        {
            _logger.LogInformation($"Search query:{query}");
            return Ok();
        }
    }
}
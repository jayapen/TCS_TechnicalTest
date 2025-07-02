using Microsoft.AspNetCore.Mvc;

namespace TCSTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //test controller
    public class TestController : ControllerBase
    {       

        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Cool");
        }
    }
}

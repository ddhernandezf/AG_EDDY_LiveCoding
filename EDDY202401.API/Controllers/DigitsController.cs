using Microsoft.AspNetCore.Mvc;

namespace EDDY202401.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DigitsController : ControllerBase
    {
        private static int[] data => Enumerable.Range(1, 100).ToArray();

        [HttpGet]
        public IActionResult Get() => Ok(new { count = data.Length, data });
    }
}

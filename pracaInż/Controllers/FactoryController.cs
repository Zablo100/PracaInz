using Microsoft.AspNetCore.Mvc;
using pracaInż.Services;

namespace pracaInż.Controllers
{
    [ApiController]
    [Route("api/v1/Factory")]
    public class FactoryController : Controller
    {
        private readonly IFactoryService _factoryService;

        public FactoryController(IFactoryService factoryService)
        {
            _factoryService = factoryService;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var list = await _factoryService.GetFactoriesAsync();

            return Ok(list);
        }
    }
}

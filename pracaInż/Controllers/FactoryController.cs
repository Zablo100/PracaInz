using Microsoft.AspNetCore.Mvc;
using pracaInż.Services;

namespace pracaInż.Controllers
{
    [ApiController]
    [Route("api/v1/Factory/[action]")]
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
            var result = await _factoryService.GetFactoriesAsync();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetFactoriesWithoutDepartments()
        {
            var result = await _factoryService.GetFactriesWithOutDepartments();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFactoryById(int id)
        {
            var result = await _factoryService.GetFactoryById(id);

            return Ok(result);
        }


    }
}

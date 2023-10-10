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

            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> Testowe()
        {
            var test = await _factoryService.Test();

           if (test.IsError)
            {
                return BadRequest(test.FirstError);
            }

           return Ok(new {Message = "Pomyślnie utworzono obiekty: Fabryka"});
        }
    }
}

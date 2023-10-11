using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using pracaInż.Models.DTO.Factories;
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

        [HttpPost]
        public async Task<IActionResult> createNewFactory([FromBody] AddFactoryDTO factoryDTO)
        {
            var result = await _factoryService.CreateNewFactory(factoryDTO);

            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            //TODO: Stworzyć obiekt z informacjami do powiadomienia w forntendzie (Status, Komunikat)
            return Ok(new {Message = "Pomyślnie utworzono obiekty Fabryka"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteFactoryById(int id)
        {
            var result = await _factoryService.DeleteFactory(id);

            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            //TODO: Stworzyć obiekt z informacjami do powiadomienia w forntendzie (Status, Komunikat)
            return Ok(result.Value);
        }
    }
}

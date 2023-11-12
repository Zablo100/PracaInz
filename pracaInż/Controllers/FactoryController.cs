using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using pracaInż.Models;
using pracaInż.Models.DTO.Factories;
using pracaInż.Models.Entities.CompanyStructure;
using pracaInż.Services;

namespace pracaInż.Controllers
{
    [ApiController]
    [Route("api/Factory/[action]")]
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
            if (result.Count == 0)
            {
                return Ok(new NotificationResponse(2, "Błąd ładowania zawartości!"));
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetFactoriesWithoutDepartments()
        {
            var result = await _factoryService.GetFactriesWithOutDepartments();
            if (result.Count == 0)
            {
                return Ok(new NotificationResponse(2, "Błąd ładowania zawartości!"));
            }

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

            return Ok(new NotificationResponse(0, "Pomyślnie utworzono fabryke!"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteFactoryById(int id)
        {
            var result = await _factoryService.DeleteFactory(id);

            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(new NotificationResponse(0, "Pomyślnie usunięto fabryke!"));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFactory([FromBody] UpdateFactoryDTO factoryDTO)
        {
            var result = await _factoryService.UpdateFactory(factoryDTO);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(new NotificationResponse(0, $"Pomyślnie zaktualizowane dane fabryki: {factoryDTO.Street} {factoryDTO.StreetNumber}"));
        }

        [HttpGet]
        public async Task<IActionResult> GetDataForSelectElement()
        {
            var result = await _factoryService.GetFactoryForSelect();
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> SearchFactoryByQuery([FromBody] FactorySearchDTO search)
        {
            var result = await _factoryService.SearchFactoryByQuery(search.Query);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }
    }
}

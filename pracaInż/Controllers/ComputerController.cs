using Microsoft.AspNetCore.Mvc;
using pracaInż.Models;
using pracaInż.Models.Entities.Inventory;
using pracaInż.Services;

namespace pracaInż.Controllers
{
    [ApiController]
    [Route("Computers/[action]")]
    public class ComputerController : Controller
    {
        private readonly IComputerService _service;
        public ComputerController(IComputerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetComputers(int page)
        {
            var result = await _service.GetComputerAsync(page);
            if(result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }
        
    }
}

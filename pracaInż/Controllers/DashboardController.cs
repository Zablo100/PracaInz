using Microsoft.AspNetCore.Mvc;
using pracaInż.Services;

namespace pracaInż.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : Controller
    {
        private readonly IDashboardServices _services;
        public DashboardController(IDashboardServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> getAllCriticallDeviceStatus()
        {
            var status = await _services.getInfrastructureStatus();

            return Ok(status);
        }
    }
}

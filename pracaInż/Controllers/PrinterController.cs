using Microsoft.AspNetCore.Mvc;
using pracaInż.Models.DTO.Printers;
using pracaInż.Services;

namespace pracaInż.Controllers
{
    [ApiController]
    [Route("api/department/[action]")]
    public class PrinterController : Controller
    {
        private readonly IPrinterService _printerService;

        public PrinterController(IPrinterService printerService)
        {
            _printerService = printerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetArcusPrinters()
        {
            var printers = await _printerService.GetArcusPrinters();

            return Ok(printers);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewArcusPrinter(AddArcusPrinterDTO printerDTO)
        {
            await _printerService.AddNewArcusPrinter(printerDTO);

            return Ok();
        }




    }
}

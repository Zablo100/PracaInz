using Microsoft.AspNetCore.Mvc;
using pracaInż.Models.DTO.Printers;
using pracaInż.Services;

namespace pracaInż.Controllers
{
    [ApiController]
    [Route("api/printers/[action]")]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangePrinterStatus(int id)
        {
            await _printerService.ChangePrinterStatus(id);
         
            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> ClearAllPrintersStatus()
        {
            await _printerService.ChangeAllPrintersStatus();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletArcusPrinter(int id)
        {
            await _printerService.RemoveArcusPrinters(id);

            return Ok();
        }



    }
}

using Microsoft.AspNetCore.Mvc;
using pracaInż.Services;

namespace pracaInż.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _service;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _service = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if(result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> TotalMoneySpendInYear()
        {
            var result = await _service.TotalMoneySpendForTimePeriod();
            if(result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }
    }
}

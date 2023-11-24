using Microsoft.AspNetCore.Mvc;
using pracaInż.Models.DTO.TicketDTO;
using pracaInż.Services;

namespace pracaInż.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TicketController : Controller
    {
        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitTicket(NewTicketDTO ticket)
        {
            var result = await _service.SubmitNewTicketAsync(ticket);
            if(result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value.ToString());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var result = await _service.GetTicketsAsync();
            if(result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }
    }
}

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
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value.ToString());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var result = await _service.GetTicketsAsync();
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var result = await _service.GetTicketByIdAsync(id);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> AddCommentToTicket([FromBody] AddCommentDTO comment)
        {
            var result = await _service.AddCommentToTicketAsync(comment);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> AcceptTicket(AcceptTicketDTO acceptTicket)
        {
            var result = await _service.AcceptTicket(acceptTicket);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value.ToString());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CompletTicket(int id)
        {
            var result = await _service.ResolveTicket(id);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value.ToString());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSummaryById(int id)
        {
            var result = await _service.GetPersonTicketSummary(id);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByPreson(int id)
        {
            var result = await _service.GetTicketsByPreson(id);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }
    }
}

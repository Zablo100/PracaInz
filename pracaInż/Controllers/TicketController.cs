﻿using Microsoft.AspNetCore.Mvc;
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

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets(int page)
        {
            var result = await _service.GetTicketsAsync(page);
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByPC(int id)
        {
            var result = await _service.GetTicketsByPc(id);
            if (result.IsError)
            {
                return BadRequest(result.FirstError);
            }

            return Ok(result.Value);
        }
    }
}

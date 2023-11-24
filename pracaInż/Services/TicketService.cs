using ErrorOr;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.DTO.TicketDTO;
using pracaInż.Models.Entities;

namespace pracaInż.Services
{
    public interface ITicketService
    {
        Task<ErrorOr<Created>> SubmitNewTicketAsync(NewTicketDTO ticketDTO);
        Task<ErrorOr<List<TicketDTO>>> GetTicketsAsync();

    }
    public class TicketService : ITicketService
    {
        private readonly AppDbcontext _context;

        public TicketService(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<ErrorOr<List<TicketDTO>>> GetTicketsAsync()
        {
            ErrorOr<List<TicketDTO>> Result;
            var tickets = await _context.Tickets
                .Include(t => t.AcceptedBy)
                .Include(t => t.SubmittedBy)
                .ThenInclude(emp => emp.Department)
                .Include(t => t.Computer)
                .ToListAsync();
            List<TicketDTO> ticketDTOs = new List<TicketDTO>();
            foreach (var ticket in tickets)
            {
                ticketDTOs.Add(new TicketDTO(ticket));
            }

            if(ticketDTOs.Count <= 0) 
            {
                Result = Error.NotFound(description: "Brak elementów w bazie danych!");
                return Result;
            }

            Result = ticketDTOs;
            return Result;
        }

        public async Task<ErrorOr<Created>> SubmitNewTicketAsync(NewTicketDTO ticketDTO)
        {
            ErrorOr<Created> result;

            //walidacja

            Ticket ticket = new Ticket(ticketDTO);

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            result = Result.Created;

            return result;
        }
    }
}

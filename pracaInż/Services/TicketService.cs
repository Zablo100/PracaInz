using ErrorOr;
using pracaInż.Data;
using pracaInż.Models.DTO.TicketDTO;
using pracaInż.Models.Entities;

namespace pracaInż.Services
{
    public interface ITicketService
    {
        Task<ErrorOr<Created>> SubmitNewTicketAsync(NewTicketDTO ticketDTO);
    }
    public class TicketService : ITicketService
    {
        private readonly AppDbcontext _context;

        public TicketService(AppDbcontext context)
        {
            _context = context;
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

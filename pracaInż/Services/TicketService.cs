using ErrorOr;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models;
using pracaInż.Models.DTO.TicketDTO;
using pracaInż.Models.Entities;

namespace pracaInż.Services
{
    public interface ITicketService
    {
        Task<ErrorOr<Created>> SubmitNewTicketAsync(NewTicketDTO ticketDTO);
        Task<ErrorOr<PaginationResponse<List<TicketDTO>>>> GetTicketsAsync(int page);
        Task<ErrorOr<TicketDTO>> GetTicketByIdAsync(int id);
        Task<ErrorOr<CommentDTO>> AddCommentToTicketAsync(AddCommentDTO commentDTO);
        Task<ErrorOr<List<TicketDTO>>> GetTicketsByPc(int id);

    }
    public class TicketService : ITicketService
    {
        private readonly AppDbcontext _context;

        public TicketService(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<ErrorOr<CommentDTO>> AddCommentToTicketAsync(AddCommentDTO commentDTO)
        {
            ErrorOr<CommentDTO> result;

            var comment = new Comment(commentDTO);

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            result = new CommentDTO(comment);
            return result;
        }

        public async Task<ErrorOr<TicketDTO>> GetTicketByIdAsync(int id)
        {
            ErrorOr<TicketDTO> result;

            var ticket = await _context.Tickets
                .Include(t => t.Computer)
                .FirstOrDefaultAsync(ticket => ticket.Id == id);

            if (ticket == null)
            {
                result = Error.NotFound(description: "Nie znaleziono zgłoszenia o podanym numerze(ID)");
                return result;
            }

            var ticketDTO = new TicketDTO(ticket);
            ticketDTO.Comments = _context.Comments
                .Where(comm => comm.TicketId == id)
                .Select(comm => new CommentDTO(comm))
                .ToList();

            result = ticketDTO;

            return result;
        }
        
        public async Task<ErrorOr<PaginationResponse<List<TicketDTO>>>> GetTicketsAsync(int page)
        {
            ErrorOr<PaginationResponse<List<TicketDTO>>> Result;
            var tickets = await _context.Tickets
                .Skip((page - 1) * 10)
                .Take(10)
                .OrderBy(t => t.Id)
                .Include(t => t.Computer)
                .ToListAsync();

            var totalCount = await _context.Tickets.CountAsync();

            List<TicketDTO> ticketDTOs = new List<TicketDTO>();

            foreach (var ticket in tickets)
            {
                ticketDTOs.Add(new TicketDTO(ticket));
            }

            if(ticketDTOs.Count <= 0) 
            {
                Result = Error.NotFound(description: "Brak zgłoszeń!");
                return Result;
            }



            Result = new PaginationResponse<List<TicketDTO>>(page, totalCount, 10, ticketDTOs);
            return Result;
        }

        public async Task<ErrorOr<Created>> SubmitNewTicketAsync(NewTicketDTO ticketDTO)
        {
            ErrorOr<Created> result;

            Ticket ticket = new Ticket(ticketDTO);

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            result = Result.Created;

            return result;
        }

        public async Task<ErrorOr<List<TicketDTO>>> GetTicketsByPc(int id)
        {
            ErrorOr<List<TicketDTO>> Result;
            var tickets = await _context.Tickets
                .Where(t => t.ComputerId == id)
                .Include(t => t.Computer)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            List<TicketDTO> ticketDTOs = new List<TicketDTO>();

            foreach (var ticket in tickets)
            {
                ticketDTOs.Add(new TicketDTO(ticket));
            }

            if (ticketDTOs.Count <= 0)
            {
                Result = Error.NotFound(description: "Brak zgłoszeń!");
                return Result;
            }



            Result = ticketDTOs;
            return Result;
        }
    }
}

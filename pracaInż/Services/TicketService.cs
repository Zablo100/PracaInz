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
        Task<ErrorOr<TicketDTO>> GetTicketByIdAsync(int id);
        Task<ErrorOr<CommentDTO>> AddCommentToTicketAsync(AddCommentDTO commentDTO);
        Task<ErrorOr<Updated>> AcceptTicket(AcceptTicketDTO request);
        Task<ErrorOr<Updated>> ResolveTicket(int ticketId);
        Task<ErrorOr<List<List<string>>>> GetPersonTicketSummary(int presonId);
        Task<ErrorOr<List<TicketDTO>>> GetTicketsByPreson(int id);

    }
    public class TicketService : ITicketService
    {
        private readonly AppDbcontext _context;

        public TicketService(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<ErrorOr<Updated>> AcceptTicket(AcceptTicketDTO request)
        {
            ErrorOr<Updated> result;
            var ticket = await _context.Tickets.FindAsync(request.TicketId);
            if (ticket == null)
            {
                result = Error.NotFound(description: "Nie można odnaleźć zgłoszenia o podanym numerze(ID)");
                return result;
            }

            ticket.AcceptedById = request.AcceptedById;
            ticket.Status = Status.InProgress;
            ticket.AcceptedAt = DateTime.Now;

            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();

            result = Result.Updated;
            return result;
        }

        public async Task<ErrorOr<CommentDTO>> AddCommentToTicketAsync(AddCommentDTO commentDTO)
        {
            ErrorOr<CommentDTO> result;
            //Walidacja
            var comment = new Comment(commentDTO);

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            result = new CommentDTO(comment);
            return result;
        }

        public async Task<ErrorOr<TicketDTO>> GetTicketByIdAsync(int id)
        {
            ErrorOr<TicketDTO> result;
            //TODO: Walidacja
            var ticket = await _context.Tickets
                .Include(t => t.AcceptedBy)
                .Include(t => t.SubmittedBy)
                .ThenInclude(emp => emp.Department)
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
                Result = Error.NotFound(description: "Brak zgłoszeń!");
                return Result;
            }



            Result = ticketDTOs;
            return Result;
        }

        public async Task<ErrorOr<List<TicketDTO>>> GetTicketsByPreson(int id)
        {
            ErrorOr<List<TicketDTO>> Result;
            var tickets = await _context.Tickets
                .Where(t => t.SubmittedById == id)
                .Include(t => t.AcceptedBy)
                .Include(t => t.SubmittedBy)
                .ThenInclude(emp => emp.Department)
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
        public async Task<ErrorOr<Updated>> ResolveTicket(int ticketId)
        {
            ErrorOr<Updated> result;

            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket == null)
            {
                result = Error.NotFound(description: "Nie znaleziono zgłoszenia o podanym numerze(ID)");
                return result;
            }

            ticket.Status = Status.Completed;
            ticket.ResolvedAt = DateTime.Now;

            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();

            result = Result.Updated;
            return result;
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

        public async Task<ErrorOr<List<List<string>>>> GetPersonTicketSummary(int presonId)
        {
            ErrorOr<List<List<string>>> result;
            var year = DateTime.Now.Year;
            var start = new DateTime(year, 1, 1);
            var stop = new DateTime(year, 12, 31);
            List<Tuple<int, decimal>> raw;

            try
            {
                raw = _context.Tickets
                    .Where(inv => inv.SubmittedById == presonId && inv.CreatedAt >= start && inv.CreatedAt <= stop)
                    .GroupBy(inv => inv.CreatedAt.Month)
                    .Select(group => new Tuple<int, decimal>(group.Key, group.Count()))
                    .ToList();

            }
            catch (Exception ex)
            {
                result = Error.Failure(ex.Message);
                return result;
            }

            for (int i = 1; i <= 12; i++)
            {
                if (!raw.Any(t => t.Item1 == i))
                {
                    Tuple<int, decimal> tupla = new Tuple<int, decimal>(i, 0m);
                    raw.Add(tupla);
                }
            }

            raw.Sort((x, y) => x.Item1.CompareTo(y.Item1));
            List<List<string>> lista = new List<List<string>>();
            List<string> months = new List<string> { "Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesień", "Pażdziernik", "Listopad", "Grudzień" };
            foreach (var tupla in raw)
            {
                lista.Add(new List<string> { months[tupla.Item1 - 1], tupla.Item2.ToString("0") });
            }

            result = lista;
            return result;
        }

    }
}

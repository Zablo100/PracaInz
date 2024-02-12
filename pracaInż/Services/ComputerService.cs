using ErrorOr;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models;
using pracaInż.Models.Entities.Inventory;

namespace pracaInż.Services
{
    public interface IComputerService
    {
           public Task<ErrorOr<PaginationResponse<List<Computer>>>> GetComputerAsync(int page);
    }

    public class ComputerService : IComputerService
    {
        private readonly AppDbcontext _context;
        private readonly int NumberPerPage = 10;

        public ComputerService(AppDbcontext context)
        {
            _context = context;
        }
        public async Task<ErrorOr<PaginationResponse<List<Computer>>>> GetComputerAsync(int page)
        {
            ErrorOr<PaginationResponse<List<Computer>>> result;
            var data = await _context.Computers
                .Skip((page - 1) * NumberPerPage)
                .Take(NumberPerPage)
                .OrderBy(comp => comp.Id)
                .ToListAsync();

            if(data.Count == 0)
            {
                result = Error.NotFound(description: "Błąd, nie udało się wczytać listy urządzeń");
                return result;
            }

            var totalCount = await _context.Computers.CountAsync();

            result = new PaginationResponse<List<Computer>>(page, totalCount, NumberPerPage, data);
            return result;
        }
    }
}

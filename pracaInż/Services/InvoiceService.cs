using ErrorOr;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.DTO.Invoices;
using pracaInż.Models.Entities;

namespace pracaInż.Services
{
    public interface IInvoiceService
    {
        Task<List<InvoiceDTO>> GetAllAsync();
        Task<ErrorOr<InvoiceDTO>> GetByIdAsync(int id);
        Task<ErrorOr<List<List<string>>>> TotalMoneySpendForTimePeriod(); 
    }
    public class InvoiceService : IInvoiceService
    {

        private readonly AppDbcontext _context;

        public InvoiceService(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<List<InvoiceDTO>> GetAllAsync()
        {
            var invoices = await _context.Invoices
                .Include(inv => inv.Items)
                    .ThenInclude(item => item.Department)
                .Include(inv => inv.Items)
                    .ThenInclude(item => item.PurchaseOrderDoc)
                .ToListAsync();

            return invoices.Select(inv => new InvoiceDTO(inv)).ToList();
        }

        public async Task<ErrorOr<InvoiceDTO>> GetByIdAsync(int id)
        {
            ErrorOr<InvoiceDTO> result;
            
            var invoice = await _context.Invoices
                .Include(inv => inv.Items)
                    .ThenInclude(item => item.Department)
                .Include(inv => inv.Items)
                    .ThenInclude(item => item.PurchaseOrderDoc)
                .FirstOrDefaultAsync(inv => inv.Id == id);


            if (invoice == null)
            {
                result = Error.NotFound(description: "Bład podczas wczytywania faktury");
                return result;
            }

            result = new InvoiceDTO(invoice);
            return result;

        }

        public async Task<ErrorOr<List<List<string>>>> TotalMoneySpendForTimePeriod()
        {

            ErrorOr<List<List<string>>> result;
            var year = DateTime.Now.Year;
            var start = DateOnly.FromDateTime(new DateTime(year, 1, 1));
            var stop = DateOnly.FromDateTime(new DateTime(year, 12, 31));
            List<Tuple<int, decimal>> raw;

            try
            {
                raw = _context.Invoices
                    .Where(inv => inv.Date >= start && inv.Date <= stop)
                    .GroupBy(inv => inv.Date.Month)
                    .Select(group => new Tuple<int, decimal>(group.Key, group.Sum(inv => inv.TotalCost)))
                    .ToList();
            } catch (Exception ex)
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
                lista.Add(new List<string> { months[tupla.Item1 -1], tupla.Item2.ToString("0.00").Replace(",", ".")});
            }

            result = lista;
            return result;
        }
    }
}

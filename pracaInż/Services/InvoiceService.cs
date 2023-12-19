using ErrorOr;
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
    }
}

using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.DTO.Printers;
using pracaInż.Models.Entities.CompanyStructure;
using pracaInż.Models.Entities.Inventory;

namespace pracaInż.Services
{
    public interface IPrinterService
    {
        //Task<PrinterDTO> GetAllPrinters();
        Task<List<PrinterDTO>> GetCompnayPrinters();
        Task<List<PrinterArcusDTO>> GetArcusPrinters();
        Task<PrinterDTO> GetCompnayPrinterById(int id);
        Task<PrinterArcusDTO> GetArcusPrinterById(int id);
        Task AddNewCompnayPrinter(AddPrinterDTO printerDTO);
        Task AddNewArcusPrinter(AddArcusPrinterDTO printerArcusDTO);
        //Task<AddPrinterDTO> FullEditCompnayPrinter(PrinterDTO printerDTO);
        //Task<AddPrin>
        //Task RemoveCompnayPrinter(int id);
        //Task RemoveArcusPrinters(int id);

    }
    public class PrinterService : IPrinterService
    {
        private readonly AppDbcontext _context;
        public PrinterService(AppDbcontext context)
        {
            _context = context;
        }

        public async Task AddNewArcusPrinter(AddArcusPrinterDTO printerArcusDTO)
        {
            Department? department = await _context.Departments.FindAsync(printerArcusDTO.DepartmentId);

            if (department == null)
            {
                return; // TODO: Błąd
            }

            PrinterArcus printer = new PrinterArcus(printerArcusDTO, department); 

            _context.PrintersArcus.Add(printer);
            await _context.SaveChangesAsync();
        }

        public async Task AddNewCompnayPrinter(AddPrinterDTO printerDTO)
        {
            Department? department = await _context.Departments.FindAsync(printerDTO.DepartmentId);

            if (department == null)
            {
                return; // TODO: Błąd
            }

            Printer printer = new Printer(printerDTO, department);

            _context.Printers.Add(printer);
            await _context.SaveChangesAsync();
        }

        public Task<PrinterArcusDTO> GetArcusPrinterById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PrinterArcusDTO>> GetArcusPrinters()
        {
            List<PrinterArcusDTO> result = new List<PrinterArcusDTO>();
            var printers = await _context.PrintersArcus.Include(printer => printer.Department).ToListAsync();
            
            foreach (var printer in printers)
            {
                result.Add(new PrinterArcusDTO(printer));
            }

            return result;
        }

        public Task<PrinterDTO> GetCompnayPrinterById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PrinterDTO>> GetCompnayPrinters()
        {
            throw new NotImplementedException();
        }
    }
}

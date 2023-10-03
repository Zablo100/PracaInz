using pracaInż.Models.DTO.Printers;

namespace pracaInż.Services
{
    public interface IPrinterService
    {
        //Task<PrinterDTO> GetAllPrinters();
        Task<List<PrinterDTO>> GetCompnayPrinters();
        Task<List<PrinterArcusDTO>> GetArcusPrinters();
        Task<PrinterDTO> GetCompnayPrinterById(int id);
        Task<PrinterArcusDTO> GetArcusPrinterById(int id);
        Task AddNewCompnayPrinter(PrinterDTO printerDTO);
        Task AddNewArcusPrinter(PrinterArcusDTO printerArcusDTO);
        Task<AddPrinterDTO> FullEditCompnayPrinter(PrinterDTO printerDTO);
        //Task<AddPrin>
        Task RemoveCompnayPrinter(int id);
        Task RemoveArcusPrinters(int id);

    }
    public class PrinterService
    {
    }
}

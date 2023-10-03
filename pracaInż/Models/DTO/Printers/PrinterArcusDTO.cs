using pracaInż.Models.Entities.CompanyStructure;
using pracaInż.Models.Entities.Inventory;

namespace pracaInż.Models.DTO.Printers
{
    public class PrinterArcusDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string IP { get; set; }
        public string Department { get; set; }
        public string SerialNumber { get; set; }
        public string InvoiceDescription { get; set; }
        public string ContractNumber { get; set; }
        public bool MonthlyCheck { get; set; }

        public PrinterArcusDTO(PrinterArcus printer)
        {
            Id = printer.Id;
            Model = printer.Model;
            Manufacturer = printer.Manufacturer;
            Description = printer.Description;
            IP = printer.IP;
            Department = printer.Department.ShortName;
            SerialNumber = printer.SerialNumber;
            InvoiceDescription = printer.InvoiceDescription;
            ContractNumber = printer.ContractNumber;
            MonthlyCheck = printer.MonthlyCheck;
        }
    }
}

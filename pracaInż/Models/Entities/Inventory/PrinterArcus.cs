using pracaInż.Models.DTO.Printers;
using pracaInż.Models.Entities.CompanyStructure;

namespace pracaInż.Models.Entities.Inventory
{
    public class PrinterArcus : Printer
    {
        public string SerialNumber { get; set; }
        public string InvoiceDescription { get; set; }
        public string ContractNumber { get; set; }
        public bool MonthlyCheck { get; set; }

        public PrinterArcus()
        {
            
        }

        public PrinterArcus(AddArcusPrinterDTO printer, Department department)
        {
            Model = printer.Model;
            Manufacturer = printer.Manufacturer;
            Description = printer.Description;
            IP = printer.IP;
            SerialNumber = printer.SerialNumber;
            InvoiceDescription = printer.InvoiceDescription;
            ContractNumber = printer.ContractNumber;
            MonthlyCheck = false;

            Department = department;
            DepartmentId = department.Id;
        }

    }
}

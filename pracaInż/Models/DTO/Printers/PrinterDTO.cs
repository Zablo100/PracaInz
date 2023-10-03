using pracaInż.Models.Entities.CompanyStructure;
using pracaInż.Models.Entities.Inventory;

namespace pracaInż.Models.DTO.Printers
{
    public class PrinterDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string IP { get; set; }
        public string Department { get; set; }

        public PrinterDTO(Printer printer)
        {
            Id = printer.Id;
            Model = printer.Model;
            Manufacturer = printer.Manufacturer;
            Description = printer.Description;
            IP = printer.IP;
            Department = printer.Department.ShortName;
        }
    }
}

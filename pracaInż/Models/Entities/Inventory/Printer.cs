using pracaInż.Models.DTO.Printers;
using pracaInż.Models.Entities.CompanyStructure;

namespace pracaInż.Models.Entities.Inventory
{
    public class Printer
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string IP { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public Printer()
        {
            
        }

        public Printer(AddPrinterDTO printerDTO, Department department)
        {
            Model = printerDTO.Model;
            Manufacturer = printerDTO.Manufacturer;
            Description = printerDTO.Description;
            IP = printerDTO.IP;
            DepartmentId = department.Id;
            Department = department;
        }

    }
}
using System.ComponentModel.DataAnnotations;

namespace pracaInż.Models.DTO.Printers
{
    public class AddArcusPrinterDTO
    {
        [Required]
        public string Model { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string IP { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        public string InvoiceDescription { get; set; }
        [Required]
        public string ContractNumber { get; set; }
    }
}

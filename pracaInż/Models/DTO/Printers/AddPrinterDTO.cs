using System.ComponentModel.DataAnnotations;

namespace pracaInż.Models.DTO.Printers
{
    public class AddPrinterDTO
    {
        [Required]
        public string Model { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string IP { get; set; }
        [Required]
        public int DepartmentId { get; set; }

    }
}

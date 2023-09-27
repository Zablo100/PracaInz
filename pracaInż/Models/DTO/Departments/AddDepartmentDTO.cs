using pracaInż.Models.Entities.CompanyStructure;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace pracaInż.Models.DTO.Departments
{
    public class AddDepartmentDTO
    {
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Skrót jest wymagany")]
        public string ShortName { get; set; }
        [Required(ErrorMessage = "Kod jednostki organizacyjnej jest wymagana")]
        public string InvoiceCode { get; set; }
        [Required(ErrorMessage = "Przypiszanie działu do fabryki jet wymagane")]
        public int FactoryId { get; set; }

    }
}

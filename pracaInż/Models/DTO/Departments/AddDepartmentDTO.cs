using pracaInż.Models.Entities.CompanyStructure;
using System.Text.Json.Serialization;

namespace pracaInż.Models.DTO.Departments
{
    public class AddDepartmentDTO
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string InvoiceCode { get; set; }
        public int FactoryId { get; set; }

    }
}

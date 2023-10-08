using pracaInż.Models.Entities.CompanyStructure;
using System.Text.Json.Serialization;

namespace pracaInż.Models.DTO.Departments
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string InvoiceCode { get; set; }
        public int FactoryId { get; set; }

        public DepartmentDTO(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            ShortName = department.ShortName;
            InvoiceCode = department.InvoiceCode;
            FactoryId = department.FactoryId;
        }
    }
}

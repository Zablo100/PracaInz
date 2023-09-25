using pracaInż.Models.Entities.CompanyStructure;
using System.Text.Json.Serialization;

namespace pracaInż.Models.DTO.Departments
{
    public class DepartmentListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string InvoiceCode { get; set; }
        public string FactoryLocation { get; set; }

        public DepartmentListDTO(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            ShortName = department.ShortName;
            InvoiceCode = department.InvoiceCode;
            FactoryLocation = department.Factory.City;
        }
    }
}

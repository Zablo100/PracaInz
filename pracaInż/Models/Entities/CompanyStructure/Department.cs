using pracaInż.Models.DTO.Departments;
using pracaInż.Models.DTO.Factories;
using System.Text.Json.Serialization;

namespace pracaInż.Models.Entities.CompanyStructure
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string InvoiceCode { get; set; }

        [JsonIgnore]
        public int FactoryId { get; set; }
        [JsonIgnore]
        public Factory Factory { get; set; }
        public List<Employee> Employees { get; set; }

        public Department()
        {
        
        }

        public Department(AddDepartmentDTO departmentDTO, Factory factory)
        {
            Name = departmentDTO.Name;
            ShortName = departmentDTO.ShortName;
            InvoiceCode = departmentDTO.InvoiceCode;
            FactoryId = departmentDTO.FactoryId;
            Factory = factory;
        }

        public Department(DepartmentDTO departmentDTO, Factory factory)
        {
            Id = departmentDTO.Id;
            Name = departmentDTO.Name;
            ShortName = departmentDTO.ShortName;
            InvoiceCode = departmentDTO.InvoiceCode;

            Factory = factory;
            FactoryId = factory.Id;
        }

        public Department(UpdateDepartmentDTO departmentDTO)
        {
            Id = departmentDTO.Id;
            Name = departmentDTO.Name;
            ShortName = departmentDTO.ShortName;
            InvoiceCode = departmentDTO.InvoiceCode;
            FactoryId = departmentDTO.FactoryId;
        }

    }
}

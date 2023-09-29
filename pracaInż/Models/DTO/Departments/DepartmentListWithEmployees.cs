using pracaInż.Models.DTO.Employees;
using pracaInż.Models.Entities.CompanyStructure;

namespace pracaInż.Models.DTO.Departments
{
    public class DepartmentListWithEmployees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string InvoiceCode { get; set; }
        public string FactoryLocation { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
        public DepartmentListWithEmployees(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            ShortName = department.ShortName;
            InvoiceCode = department.InvoiceCode;
            FactoryLocation = department.Factory.City;
            List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();
            foreach(Employee employee in department.Employees)
            {
                employeeDTOs.Add(new EmployeeDTO(employee));
            }
            Employees = employeeDTOs;
        }

    }
}

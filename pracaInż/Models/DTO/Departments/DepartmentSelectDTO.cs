using pracaInż.Models.Entities.CompanyStructure;

namespace pracaInż.Models.DTO.Departments
{
    public class DepartmentSelectDTO
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string ShortName { set; get; }
        public string City { get; set; }

        public DepartmentSelectDTO(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            ShortName = department.ShortName;
            City = department.Factory.City;
        }
    }
}

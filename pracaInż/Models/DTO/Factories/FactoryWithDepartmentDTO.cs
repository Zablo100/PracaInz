using pracaInż.Models.DTO.Departments;
using pracaInż.Models.Entities.CompanyStructure;

namespace pracaInż.Models.DTO.Factories
{
    public class FactoryWithDepartmentDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string PostalCode { get; set; }
        
        public List<DepartmentDTO> Departments { get; set; }


        public FactoryWithDepartmentDTO()
        {

        }
        public FactoryWithDepartmentDTO(Factory factory)
        {
            Id = factory.Id;
            City = factory.City;
            Street = factory.Street;
            StreetNumber = factory.StreetNumber;
            PostalCode = factory.PostalCode;
            Departments = new List<DepartmentDTO>();
            foreach(var dep in factory.Departments)
            {
                Departments.Add(new DepartmentDTO(dep));
            }
        }
    }
}

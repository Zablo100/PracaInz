using pracaInż.Models.Entities.CompanyStructure;


namespace pracaInż.Models.DTO.Factories
{
    public class FactorySelectDTO
    {
        public int Id { get; set; }
        public string City { get; set; }

        public FactorySelectDTO(Factory factory)
        {
            Id = factory.Id;
            City = factory.City;
        }
    }
}

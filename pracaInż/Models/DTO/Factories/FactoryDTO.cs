using pracaInż.Models.Entities.CompanyStructure;

namespace pracaInż.Models.DTO.Factories
{
    public class FactoryDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string PostalCode { get; set; }

        public FactoryDTO(Factory factory)
        {
            Id = factory.Id;
            City = factory.City;
            Street = factory.Street;
            StreetNumber = factory.StreetNumber;
            PostalCode = factory.PostalCode;
        }
    }
}

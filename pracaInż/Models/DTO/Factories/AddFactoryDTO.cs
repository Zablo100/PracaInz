using System.ComponentModel.DataAnnotations;

namespace pracaInż.Models.DTO.Factories
{
    public class AddFactoryDTO
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string PostalCode { get; set; }

    }
}

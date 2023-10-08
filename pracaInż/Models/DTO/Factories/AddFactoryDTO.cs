using System.ComponentModel.DataAnnotations;

namespace pracaInż.Models.DTO.Factories
{
    public class AddFactoryDTO
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int StreetNumber { get; set; }
        [Required]
        public string PostalCode { get; set; }

    }
}

using pracaInż.Models.Entities;

namespace pracaInż.Models.DTO.SoftwareDTOs
{
    public class SoftwareDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string? AuthorEmail { get; set; }
        public string? PhoneNumber { get; set; }

        public SoftwareDTO()
        {
            
        }

        public SoftwareDTO(Software software)
        {
            Id = software.Id;
            Name = software.Name;
            Description = software.Description;
            Author = software.Author;
            AuthorEmail = software.AuthorEmail;
            PhoneNumber = software.PhoneNumber;
        }
    }
}

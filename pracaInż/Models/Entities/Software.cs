using pracaInż.Models.DTO.SoftwareDTOs;

namespace pracaInż.Models.Entities
{
    public class Software
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string? AuthorEmail { get; set; }
        public string? PhoneNumber { get; set; }
        public int Support {  get; set; }

        public List<Employee> Employees { get; set; }

        public Software()
        {
            
        }

        public Software(AddSoftwareDTO softwareDTO)
        {
            Name = softwareDTO.Name;
            Description = softwareDTO.Description;
            Author = softwareDTO.Author;
            AuthorEmail = softwareDTO.AuthorEmail;
            PhoneNumber = softwareDTO.PhoneNumber;
            Support = softwareDTO.Support;
        }

        public Software(SoftwareDTO softwareDTO)
        {
            Id = softwareDTO.Id;
            Name = softwareDTO.Name;
            Description = softwareDTO.Description;
            Author = softwareDTO.Author;
            AuthorEmail = softwareDTO.AuthorEmail;
            PhoneNumber = softwareDTO.PhoneNumber;
            Support = softwareDTO.Support;
        }
    }
}

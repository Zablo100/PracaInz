namespace pracaInż.Models.DTO.SoftwareDTOs
{
    public class AddSoftwareDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string? AuthorEmail { get; set; }
        public string? PhoneNumber { get; set; }
    }
}

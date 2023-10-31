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

        public List<Employee> Employees { get; set; }
    }
}

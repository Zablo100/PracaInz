namespace pracaInż.Models.Entities.CompanyStructure
{
    public class Factory
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string PostalCode { get; set; }

        public List<Department> Departments { get; set; }
    }
}

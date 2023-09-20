namespace pracaInż.Models.Entities.CompanyStructure
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string InvoiceCode { get; set; }

        public int FactoryId { get; set; }
        public Factory Factory { get; set; }


    }
}

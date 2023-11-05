namespace pracaInż.Models.DTO.Departments
{
    public class UpdateDepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string InvoiceCode { get; set; }
        public int FactoryId { get; set; }
    }
}

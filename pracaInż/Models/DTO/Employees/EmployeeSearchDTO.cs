namespace pracaInż.Models.DTO.Employees
{
    public class EmployeeSearchDTO
    {
        public int DepartmentId { get; set; }
        public int FactoryId { get; set; }
        public string Query { get; set; }
    }
}

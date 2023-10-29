namespace pracaInż.Models.DTO.Employees
{
    public class AddEmployeeBasiInfoDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public int DepartmentId { get; set; }
    }
}

namespace pracaInż.Models.DTO.Employees
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string WorkPhone { get; set; }
        public string JobTitle { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public EmployeeDTO(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Surname = employee.Surname;
            EmailAddress = employee.EmailAddress;
            WorkPhone = employee.WorkPhone;
            JobTitle = employee.JobTitle;
            Username = employee.Username;
            Role = employee.Role;
        }
    }
}

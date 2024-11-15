﻿namespace pracaInż.Models.DTO.Employees
{
    public class EmployeeBasicInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentShortName { get; set; }
        public string FactoryLocation { get; set; }
        public int FactoryId { get; set; }
        public int DepartmentId { get; set; }

        public EmployeeBasicInfoDTO(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Surname = employee.Surname; // TODO: Sprawdzić pisowanie
            Email = employee.EmailAddress;
            WorkPhoneNumber = employee.WorkPhone;
            JobTitle = employee.JobTitle;
            DepartmentName = employee.Department.Name;
            DepartmentShortName = employee.Department.ShortName;
            FactoryLocation = employee.Department.Factory.City;
            FactoryId = employee.Department.FactoryId;
            DepartmentId = employee.DepartmentId;
        }

    }
}

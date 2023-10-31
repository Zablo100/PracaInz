using pracaInż.Models.DTO.Employees;
using pracaInż.Models.Entities;
using pracaInż.Models.Entities.CompanyStructure;
using System;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string EmailAddress { get; set; }
    public string WorkPhone { get; set; }
    public string JobTitle { get; set; }

    public int DepartmentId { get; set; }   
    public Department Department { get; set; }

    public List<Software> SoftwareAccessList { get; set; }

    public Employee()
    {

    }

    public Employee(AddEmployeeBasiInfoDTO employeeDTO, Department department)
    {
        Name = employeeDTO.Name;
        Surname = employeeDTO.Surname;
        EmailAddress = employeeDTO.Email;
        WorkPhone = employeeDTO.WorkPhoneNumber;
        JobTitle = employeeDTO.JobTitle;
        Department = department;
        DepartmentId = department.Id;
    }

    public Employee(UpdateEmployeeDTO employeeDTO, Department department)
    {
        Id = employeeDTO.Id;
        Name = employeeDTO.Name;
        Surname = employeeDTO.Surname;
        EmailAddress = employeeDTO.Email;
        WorkPhone = employeeDTO.WorkPhoneNumber;
        JobTitle = employeeDTO.JobTitle;
        Department = department;
        DepartmentId = department.Id;
    }


}

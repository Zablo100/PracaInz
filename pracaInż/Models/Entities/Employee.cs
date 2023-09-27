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


}

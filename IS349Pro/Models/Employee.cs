using System;
namespace IS349Pro.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public double Salary { get; set; }
    public int PositionId { get; set; }
    public int DepartmentId { get; set; }
    public bool IsActive { get; set; }
}


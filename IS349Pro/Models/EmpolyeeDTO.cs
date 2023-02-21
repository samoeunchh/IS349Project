using System;
namespace IS349Pro.Models
{
	public class EmpolyeeDTO
	{
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
        public string PositionName { get; set; }
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
    }
}


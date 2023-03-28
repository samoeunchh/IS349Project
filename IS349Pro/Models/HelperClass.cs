using System;
namespace IS349Pro.Models;

public class HelperClass
{
    private readonly Dbcontext _context;
    public HelperClass()
	{
        _context = new Dbcontext();
    }
    public List<Position> GetPositions()
    {
        var position = _context.ReadData("SELECT PositionId,PositionName FROM Position");
        var positions = new List<Position>();
        while (position.Read())
        {
            positions.Add(new Position
            {
                PositionId = int.Parse(position[0].ToString()),
                PositionName = position[1].ToString()
            });
        }
        position.Close();
        return positions;
    }
    public List<Department> GetDepartments()
    {
        var department = _context.ReadData("SELECT DepartmentId,DepartmentName FROM Department");
        var departments = new List<Department>();
        while (department.Read())
        {
            departments.Add(new Department
            {
                DepartmentId = int.Parse(department[0].ToString()),
                DepartmentName = department[1].ToString()
            });
        }
        department.Close();
        return departments;
    }
}


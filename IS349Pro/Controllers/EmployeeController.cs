using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IS349Pro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IS349Pro.Controllers;

public class EmployeeController : Controller
{
    private readonly Dbcontext _context;
    public EmployeeController()
    {
        _context = new Dbcontext();
    }
    // GET: Employee
    public ActionResult Index()
    {
        return View();
    }
    public JsonResult GetEmployee(string q)
    {
        string sql = "SELECT e.EmployeeId,e.EmployeeName,e.Gender,e.Address,e.Salary," +
            "\np.PositionName,d.DepartmentName" +
            "\nFROM Employee e INNER JOIN [Position] p ON e.PositionId = p.PositionId" +
            "\nINNER JOIN Department d ON e.DepartmentId=d.DepartmentId";
        if (!string.IsNullOrEmpty(q))
        {
            sql += " WHERE e.EmployeeName Like N'%" + q + "%' OR p.PositionName LIKE N'%"+ q +"%'";
        }
        var empList = new List<EmpolyeeDTO>();
        var result = _context.ReadData(sql);
        while (result.Read())
        {
            empList.Add(new EmpolyeeDTO
            {
                EmployeeId = int.Parse(result["EmployeeId"].ToString()),
                EmployeeName = result["EmployeeName"].ToString(),
                Gender = result["Gender"].ToString(),
                Address = result["Address"].ToString(),
                Salary = double.Parse(result["Salary"].ToString()),
                PositionName = result["PositionName"].ToString(),
                DepartmentName = result["DepartmentName"].ToString()
            });
        }
        result.Close();
        return Json(empList);
    }
    // GET: Employee/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: Employee/Create
    public ActionResult Create()
    {
       
        ViewData["Positions"] = new SelectList(GetPositions(), "PositionId", "PositionName");
        ViewData["Departments"] = new SelectList(GetDepartments(), "DepartmentId", "DepartmentName");
        return View();
    }
    private List<Position> GetPositions()
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
    private List<Department> GetDepartments()
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
    // POST: Employee/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            // TODO: Add insert logic here

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: Employee/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: Employee/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            // TODO: Add update logic here

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: Employee/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: Employee/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            // TODO: Add delete logic here

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
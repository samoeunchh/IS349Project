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
    private readonly HelperClass _helper;
    public EmployeeController()
    {
        _context = new Dbcontext();
        _helper = new HelperClass();
    }
    // GET: Employee
    public ActionResult Index()
    {
        return View();
    }
    public JsonResult GetEmployee(string q)
    {
        var empList = new List<EmpolyeeDTO>();
        var result = _context.GetEmployee(q);
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
       
        ViewData["Positions"] = new SelectList(_helper.GetPositions(), "PositionId", "PositionName");
        ViewData["Departments"] = new SelectList(_helper.GetDepartments(), "DepartmentId", "DepartmentName");
        return View();
    }
   
   
    // POST: Employee/Create
    [HttpPost]
    //[ValidateAntiForgeryToken]
    public ActionResult Create(Employee employee)
    {
        if(ModelState.IsValid)
        {
            var sql = "INSERT INTO Employee(EmployeeName,Gender,DepartmentId,PositionId,Salary,Address) VALUES('"+
                employee.EmployeeName +"','"+ employee.Gender +"',"+ employee.DepartmentId +","+
                employee.PositionId +","+ employee.Salary +",'"+ employee.Address +"')";
            if (_context.ExecuteQuery(sql))
            {
                return RedirectToAction(nameof(Index));
            }
        }
        ViewData["Positions"] = new SelectList(_helper.GetPositions(), "PositionId", "PositionName",employee.PositionId);
        ViewData["Departments"] = new SelectList(_helper.GetDepartments(), "DepartmentId", "DepartmentName",employee.DepartmentId);
        return View();
    }

    // GET: Employee/Edit/5
    public ActionResult Edit(int id)
    {
        ViewData["Positions"] = new SelectList(_helper.GetPositions(), "PositionId", "PositionName");
        ViewData["Departments"] = new SelectList(_helper.GetDepartments(), "DepartmentId", "DepartmentName");
        var sql = "SELECT * FROM Employee WHERE EmployeeId=" + id;
        var result = _context.ReadData(sql);
        var employee = new Employee();
        if(result.Read())
        {
            employee.DepartmentId = int.Parse(result["DepartmentId"].ToString());
            employee.PositionId = int.Parse(result["PositionId"].ToString());
            employee.EmployeeName = result["EmployeeName"].ToString();
            employee.Gender = result["Gender"].ToString();
            employee.Salary = double.Parse(result["Salary"].ToString());
            employee.Address = result["Address"].ToString();
            employee.EmployeeId = int.Parse(result["EmployeeId"].ToString());
        }
        return View(employee);
    }

    // POST: Employee/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Employee employee)
    {
        if (ModelState.IsValid)
        {
            var sql = "UPDATE Employee SET EmployeeName='"+ employee.EmployeeName +"',Gender='"+
                employee.Gender+"',DepartmentId="+ employee.DepartmentId +",PositionId="+ employee.PositionId +",Salary="+ employee.Salary+",Address='"+ employee.Address+"' WHERE EmployeeId="+ id;
            if (_context.ExecuteQuery(sql))
            {
                return RedirectToAction(nameof(Index));
            }
        }
        ViewData["Positions"] = new SelectList(_helper.GetPositions(), "PositionId", "PositionName", employee.PositionId);
        ViewData["Departments"] = new SelectList(_helper.GetDepartments(), "DepartmentId", "DepartmentName", employee.DepartmentId);
        return View();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IS349Pro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        return View();
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
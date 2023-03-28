using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IS349Pro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IS349Pro.Controllers
{
    public class EmployeeReportController : Controller
    {
        private readonly Dbcontext _context;
        private readonly HelperClass _helper;
        public EmployeeReportController()
        {
            _context = new Dbcontext();
            _helper = new HelperClass();
        }
        public IActionResult Index()
        {
            ViewData["Positions"] = new SelectList(_helper.GetPositions(), "PositionId", "PositionName");
            ViewData["Departments"] = new SelectList(_helper.GetDepartments(), "DepartmentId", "DepartmentName");
            return View();
        }
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IS349Pro.Models;

namespace IS349Pro.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private Dbcontext _context;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _context = new Dbcontext();
    }

    public IActionResult Index()
    {
        var position = _context.ReadData("SELECT * FROM Position");
        var pos = new List<Position>();
        while (position.Read())
        {
            pos.Add(new Position
            {
                PositionId = int.Parse(position[0].ToString()),
                PositionName = position[1].ToString()
            });
        }
        return View(pos);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


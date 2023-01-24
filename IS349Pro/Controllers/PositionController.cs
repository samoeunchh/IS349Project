using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IS349Pro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IS349Pro.Controllers
{
    public class PositionController : Controller
    {
        private readonly Dbcontext _context;
        public PositionController()
        {
            _context = new Dbcontext();
        }
        // GET: Position
        public ActionResult Index()
        {
            var position = _context.ReadData("SELECT * FROM Position ORDER BY PositionName ASC");
            var pos = new List<Position>();
            while (position.Read())
            {
                pos.Add(new Position
                {
                    PositionId = int.Parse(position[0].ToString()),
                    PositionName = position[1].ToString()
                });
            }
            position.Close();
            return View(pos);
        }

        // GET: Position/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Position/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Position/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Position position)
        {
            try
            {
                var sql = "INSERT INTO Position(PositionName) VALUES('"+ position.PositionName+"')";
                if (_context.ExecuteQuery(sql))
                {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Position/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Position/Edit/5
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

        // GET: Position/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Position/Delete/5
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
}
using FirstCoreAppExample.Data;
using FirstCoreAppExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreAppExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly K100Context _context;
        public HomeController(ILogger<HomeController> logger,K100Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["List1"] = _context.Users.ToList();
            return View(); 
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User us)
        {
            _context.Add(us);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int ? id)
        {
            if (id == null)  return NotFound();
            User selectedUser = _context.Users.FirstOrDefault(x => x.ID == id);
            if (selectedUser == null) return NotFound();
            return View(selectedUser);
        }
        [HttpPost]
        public IActionResult Edit(User us)
        {
            _context.Users.Update(us);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int ? id)
        {
            if (id == null) return NotFound();
            User selectedUser = _context.Users.FirstOrDefault(x => x.ID == id);
            if (selectedUser == null) return NotFound();
            return View(selectedUser);
        }
        [HttpPost]
        public IActionResult Delete(User us)
        {
            _context.Users.Remove(us);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

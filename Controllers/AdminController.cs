using DigitalRetailers.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRetailers.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AdminController()
        {
            _context = new ApplicationDBContext();
        }

        public IActionResult Index()
        {
            var laptops = _context.Laptops.ToList();

            return View(laptops);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Laptop laptop)
        {
            _context.Laptops.Add(laptop);
            _context.SaveChanges();
            return RedirectToAction("Index", "Users");

        }

        public IActionResult Edit(int id)
        {
            var laptop = _context.Laptops.Where(a => a.laptopId == id).FirstOrDefault();
            return View(laptop);
            
        }

        [HttpPost]
        public IActionResult Edit(Laptop laptop)
        {
            _context.Laptops.Update(laptop);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var laptop = _context.Laptops.Where(a => a.laptopId == id).FirstOrDefault();
            _context.Laptops.Remove(laptop);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

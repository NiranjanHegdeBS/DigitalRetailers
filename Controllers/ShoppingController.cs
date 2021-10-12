using DigitalRetailers.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRetailers.Controllers
{
    public class ShoppingController : Controller
    {
        ApplicationDBContext _context;

        public ShoppingController()
        {
            _context = new ApplicationDBContext();
        }
        public IActionResult Index()
        {
            var laptops = _context.Laptops.ToList();
            return View(laptops);
        }

        public IActionResult Details(int id)
        {
            var item = _context.Laptops.Find(id);
            return View(item);
        }
    }
}

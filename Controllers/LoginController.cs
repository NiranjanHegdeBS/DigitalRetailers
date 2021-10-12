using DigitalRetailers.Models;
using Microsoft.AspNetCore.Mvc;
using SessionManagement.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRetailers.Controllers
{
    public class LoginController : Controller
    {
        ApplicationDBContext context;
        public LoginController()
        {
            context = new ApplicationDBContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(User user)
        {
            var userObj = context.Users.Where(u => u.userName == user.userName && 
            u.password == user.password && 
            u.userType == user.userType).SingleOrDefault();
            
            if (userObj != null)
            {
                SessionHelper.setObjectAsJson(HttpContext.Session, "user", userObj);

                if (user.userType.Equals("admin"))
                {
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    return RedirectToAction("Index", "Shopping");
                }
            }
            else
            {
                ViewBag.Error = "Enter Credentials";
                return View("Index");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}

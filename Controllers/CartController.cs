using DigitalRetailers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SessionManagement.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRetailers.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CartController()
        {
            _context = new ApplicationDBContext();
        }
        public IActionResult Index()
        {
            if (SessionHelper.getObjectFromJson<User>(HttpContext.Session, "user") != null)
            {
                if (SessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
                {
                    return View("EmptyCart");
                }
                List<Item> cart = SessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
                ViewBag.Total = cart.Sum(item => item.laptop.laptopPrice * item.quantity);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult Buy(int id)
        {
            if (SessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { laptop = _context.Laptops.Find(id), quantity = 1 });
                SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);

            }
            else
            {
                List<Item> cart = SessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = ifExits(id);
                if (index > -1)
                {
                    cart[index].quantity++;
                }
                else
                {
                    cart.Add(new Item { laptop = _context.Laptops.Find(id), quantity = 1 });
                }
                SessionHelper.setObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        private int ifExits(int id)
        {
            List<Item> cart = SessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].laptop.laptopId == id) return i;
            }
            return -1;
        }

        public IActionResult Checkout()
        {
            if (SessionHelper.getObjectFromJson<User>(HttpContext.Session, "user") != null)
            {
                List<Item> cart = SessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                ViewBag.Total = cart.Sum(item => item.laptop.laptopPrice * item.quantity);

                ViewBag.States = new List<SelectListItem> 
                { 
                    new SelectListItem { Text = "Andaman and Nicobar Islands",Value = "Andaman and Nicobar Islands"},
                    new SelectListItem { Text ="Andhra Pradesh",Value = "Andhra Pradesh"},
                    new SelectListItem { Text ="Arunachal Pradesh",Value = "Arunachal Pradesh"},
                    new SelectListItem { Text ="Assam",Value = "Assam"},
                    new SelectListItem { Text ="Bihar",Value = "Bihar"},
                    new SelectListItem { Text ="Chandigarh",Value = "Chandigarh"},
                    new SelectListItem { Text ="Chhattisgarh",Value = "Chhattisgarh"},
                    new SelectListItem { Text ="Dadra and Nagar Haveli",Value = "Dadra and Nagar Haveli"},
                    new SelectListItem { Text ="Daman and Diu",Value = "Daman and Diu"},
                    new SelectListItem { Text ="Delhi",Value = "Delhi"},
                    new SelectListItem { Text ="Goa",Value = "Goa"},
                    new SelectListItem { Text ="Gujarat",Value = "Gujarat"},
                    new SelectListItem { Text ="Haryana",Value = "Haryana"},
                    new SelectListItem { Text ="Himachal Pradesh",Value = "Himachal Pradesh"},
                    new SelectListItem { Text ="Jammu and Kashmir",Value = "Jammu and Kashmir"},
                    new SelectListItem { Text ="Jharkhand",Value = "Jharkhand"},
                    new SelectListItem { Text ="Karnataka",Value = "Karnataka"},
                    new SelectListItem { Text ="Kerala",Value = "Kerala"},
                    new SelectListItem { Text ="Lakshadweep",Value = "Lakshadweep"},
                    new SelectListItem { Text ="Madhya Pradesh",Value = "Madhya Pradesh"},
                    new SelectListItem { Text ="Maharashtra",Value = "Maharashtra"},
                    new SelectListItem { Text ="Manipur",Value = "Manipur"},
                    new SelectListItem { Text ="Meghalaya",Value = "Meghalaya"},
                    new SelectListItem { Text ="Mizoram",Value = "Mizoram"},
                    new SelectListItem { Text ="Nagaland",Value = "Nagaland"},
                    new SelectListItem { Text ="Odisha",Value = "Odisha"},
                    new SelectListItem { Text ="Puducherry",Value = "Puducherry"},
                    new SelectListItem { Text ="Punjab",Value = "Punjab"},
                    new SelectListItem { Text ="Rajasthan",Value = "Rajasthan"},
                    new SelectListItem { Text ="Sikkim",Value = "Sikkim"},
                    new SelectListItem { Text ="Tamil Nadu",Value = "Tamil Nadu"},
                    new SelectListItem { Text ="Telangana",Value = "Telangana"},
                    new SelectListItem { Text ="Tripura",Value = "Tripura"},
                    new SelectListItem { Text ="Uttarakhand",Value = "Uttarakhand"},
                    new SelectListItem { Text ="Uttar Pradesh",Value = "Uttar Pradesh"},
                    new SelectListItem { Text ="West Bengal",Value = "West Bengal"}

                };
                return View("Checkout");
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        [HttpPost]
        public IActionResult Checkout(Transaction transaction)
        {
            if (transaction != null)
            {
                HashSet<string> purchasedItems = new HashSet<string>();
                List<Item> cart = SessionHelper.getObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                foreach (var item in cart)
                {
                    purchasedItems.Add(item.laptop.laptopName);
                    var row = _context.Laptops.Find(item.laptop.laptopId);
                    row.laptopQuantity -= 1;
                }
                User current_user = SessionHelper.getObjectFromJson<User>(HttpContext.Session, "user");
                transaction.userId = current_user.userId;
                transaction.purchasedItems = string.Join(", ", purchasedItems);
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
                SessionHelper.removeItem(HttpContext.Session, "cart");
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index", "Shopping");
        }

        public IActionResult Clear()
        {
            SessionHelper.removeItem(HttpContext.Session, "cart");
            return View("Index");
        }
    }
}

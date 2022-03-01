using OnlineTravelGadgetsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTravelGadgetsShop.Controllers
{
    public class SignupController : Controller
    {
        OnlineTravelGadgetsEntities context = new OnlineTravelGadgetsEntities();
        [HttpGet]
        public ActionResult Signup()
        {
            Customer customer = new Customer(); 
            return View(customer);
        }
        [HttpPost]
        public ActionResult Signup(Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                foreach(Customer user in context.Customers)
                {
                    if(user.CustomerUserId==customer.CustomerUserId)
                    {
                        TempData["User_id"] = user.CustomerId;
                        break;
                    }
                }
                TempData["Username"] = customer.CustomerName;
                Cart cart = new Cart();
                cart.CustomerId = (int)TempData["User_id"];
                cart.CartId= (int)TempData["User_id"];
                context.Carts.Add(cart);
                context.SaveChanges();
                return RedirectToAction("HomePage", "Home");
            }
            return View(customer);
        }
    }
}
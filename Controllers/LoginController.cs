using OnlineTravelGadgetsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace OnlineTravelGadgetsShop.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            Customer customer = new Customer();
            return View(customer);
        }
        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            OnlineTravelGadgetsEntities context = new OnlineTravelGadgetsEntities();
            int User_id = 0;
            string User_name = string.Empty;
            foreach(Customer id in context.Customers)
            {
                if(id.CustomerUserId==customer.CustomerUserId)
                {
                    User_id = id.CustomerId;
                    User_name = id.CustomerName;
                    break;
                }
            }
            if(User_id==0)
            {
                return View(customer);
            }
            if(customer.CustomerPassword!=context.Customers.Find(User_id).CustomerPassword)
            {
                return View(customer);
            }
            TempData["Username"] = context.Customers.Find(User_id).CustomerName;
            TempData["User_id"] = User_id;
            return RedirectToAction("HomePage","Home");
        }
    }
}
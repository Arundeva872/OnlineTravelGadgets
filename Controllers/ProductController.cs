using OnlineTravelGadgetsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace OnlineTravelGadgetsShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Buy(int GadgetId)
        {
            TempData.Keep();
            OnlineTravelGadgetsEntities context = new OnlineTravelGadgetsEntities();
            context.Gadgets.Find(GadgetId).Stock--;
            context.SaveChanges();
            return RedirectToAction("purchaseconfirm",new {gadgetName=context.Gadgets.Find(GadgetId).Name});
        }
        public ActionResult purchaseconfirm(string gadgetName)
        {
            TempData.Keep();
            return View(null, null ,gadgetName);
            //return (gadgetName);
        }
    }
}
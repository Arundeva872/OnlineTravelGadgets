using OnlineTravelGadgetsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace OnlineTravelGadgetsShop.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Category(string categoryType)
        {
            TempData.Keep();
            OnlineTravelGadgetsEntities context = new OnlineTravelGadgetsEntities();
            List<Gadget> Product = new List<Gadget>();
            foreach(Gadget item in context.Gadgets)
            {
                if(item.Category==categoryType)
                {
                    Product.Add(item);
                }
            }
            ViewBag.CategoryTitle = categoryType;
            return View(Product);
        }
    }
}
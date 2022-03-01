using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTravelGadgetsShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult HomePage()
        {
            TempData.Keep();
            return View();
        }        
    }
}
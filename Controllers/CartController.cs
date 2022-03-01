using OnlineTravelGadgetsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTravelGadgetsShop.Controllers
{

    public class CartController : Controller
    {
        OnlineTravelGadgetsEntities context = new OnlineTravelGadgetsEntities();
        // GET: Cart
        public ActionResult cart()
        {
            TempData.Keep();
            List<Cartitem> cartitems = new List<Cartitem>();
            foreach (Cartitem item in context.Cartitems)
            {
                if (item.CartId == (int)TempData["User_id"])
                {
                    cartitems.Add(item);
                }
            }
            //cartitems = context.Cartitems.ToList();
            return View(cartitems);
        }
        public ActionResult AddToCart(int GadgetID)
        {
            TempData.Keep();
            Cartitem cartitem = new Cartitem();
            Cart cart = new Cart();
            cartitem.Quantity = 1;
            cartitem.CartId = (int)TempData["User_id"];
            cartitem.GadgetsId=GadgetID;
            context.Cartitems.Add(cartitem);
            context.SaveChanges();
            return RedirectToAction("cart");
        }
        public ActionResult RemoveCart(int GadgetID)
        {
            TempData.Keep();
            foreach (Cartitem item in context.Cartitems)
            {
                if (item.CartId == (int)TempData["User_id"] && item.GadgetsId== GadgetID)
                {
                    int cartitemid=item.CartItemsId;     
                    context.Cartitems.Remove(context.Cartitems.Find(cartitemid));
                    break;
                }
            }
            context.SaveChanges();
            return RedirectToAction("cart");
        }   
    }
}
using MvcShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    [CustomAuthorizeAttribute]
    public class OrderController : Controller
    {
        // GET: Order
        
        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult OrderList()
        {
            return View();
        }
    }
}
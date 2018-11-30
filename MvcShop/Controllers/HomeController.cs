using MvcShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var context = base.HttpContext;
            if (context.Session["CurrentUser"] != null && context.Session["CurrentUser"] is CurrentUser)
            {
                CurrentUser currentUser = (CurrentUser)context.Session["CurrentUser"];
                ViewBag.IsLogin = true;
                ViewBag.UserName = currentUser.UserName;
                ViewBag.CartNum = 2;
            }
            else
            {
                ViewBag.IsLogin = false;
                ViewBag.UserName = "";
                ViewBag.CartNum = 0;
            }
            
            return View();
        }
        public ActionResult Result()
        {
            return View();
        }

    }
}
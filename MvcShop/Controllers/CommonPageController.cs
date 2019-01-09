using MvcShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    public class CommonPageController : Controller
    {
        private readonly ICartService _cartService;
        public CommonPageController(ICartService cartService)
        {
            _cartService = cartService;
        }
        // GET: CommonPage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Nav()
        {
            var context = base.HttpContext;
            if (context.Session["CurrentUser"] != null && context.Session["CurrentUser"] is CurrentUser)
            {
                CurrentUser currentUser = (CurrentUser)context.Session["CurrentUser"];
                ViewBag.IsLogin = true;
                ViewBag.UserName = currentUser.UserName;
                ViewBag.CartNum = _cartService.GetCartCount(currentUser.UserId);
            }
            else
            {
                ViewBag.IsLogin = false;
                ViewBag.UserName = "";
                ViewBag.CartNum = 0;
            }
            return View();
        }
    }
}
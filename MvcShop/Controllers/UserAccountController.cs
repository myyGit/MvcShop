using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: UserAccount
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(string username,string password)
        {
            return Json(new { status = 1, data="OK",msg="Ok" });
        }
    }
}
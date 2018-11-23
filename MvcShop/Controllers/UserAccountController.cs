using Common;
using MvcShop.Entity;
using MvcShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly IUserService _userService;
        public UserAccountController(IUserService userService)
        {
            this._userService = userService;
        }

        // GET: UserAccount
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(string username,string password)
        {
            UserAccount user = _userService.GetUserByUserName(username);
            if (user == null)
            {
                return Json(new SuccessResult { status = 0, data = "OK", msg = "用户不存在" });
            }
            password = EncryptionHelper.MD5Encrypt64(password);
            if (password.Equals(user.UserPassword))
            {
                return Json(new SuccessResult { status = 1, data = "OK", msg = "Ok" });
            }
            else
            {
                return Json(new SuccessResult { status = 0, data = "OK", msg = "密码错误" });
            }
            
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            return View();
        }

        public ActionResult UserCenter()
        {
            return View();
        }

        public ActionResult UserCenterUpdate()
        {
            return View();
        }

        public ActionResult UserPassReset()
        {
            return View();
        }

        public ActionResult UserPassUpdate()
        {
            return View();
        }
    }
}
using Common;
using MvcShop.Data;
using MvcShop.Entity;
using MvcShop.Service;
using MvcShop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    [CustomAuthorizeAttribute]
    public class UserAccountController : Controller
    {
        private readonly IUserService _userService;
        private string token = "";
        public UserAccountController(IUserService userService)
        {
            this._userService = userService;
        }

        // GET: UserAccount
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult Login(string username,string password)
        {
            UserAccount user = _userService.GetUserByUserName(username);
            if (user == null)
            {
                return Json(new SuccessResult { status = 2, data = "OK", msg = "用户不存在" });
            }
            password = EncryptionHelper.MD5Encrypt64(password);
            if (password.Equals(user.UserPassword))
            {
                #region 登录成功，写入cookie，session
                CurrentUser currentUser = new CurrentUser()
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    UserPwd = user.UserPassword,
                    Email = user.UserEmail,
                    LoginTime = DateTime.Now
                };
                var context = base.HttpContext;
                #region 写入cookie
                HttpCookie cookie = new HttpCookie("CurrentUser");
                cookie.Value = JSONSerializer.ToJSONString(currentUser);
                cookie.Expires = DateTime.Now.AddMinutes(30);
                context.Response.Cookies.Add(cookie); //一定要输出
                #endregion

                #region 写入session
                var sessionUser = context.Session["CurrentUser"];
                context.Session["CurrentUser"] = currentUser;
                context.Session.Timeout = 30;  //分钟 session过期等于Abandon
                #endregion

                #endregion
                return Json(new SuccessResult { status = 1, data = "OK", msg = "Ok" });
            }
            else
            {
                return Json(new SuccessResult { status = 2, data = "OK", msg = "密码错误" });
            }
            
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult Register(RegisterModel model)
        {
            if (string.IsNullOrEmpty(model.password))
            {
                return Json(new SuccessResult { status = 2, data = "OK", msg = "请输入密码" });
            }
            UserAccount userAccount = new UserAccount();
            userAccount.Answer = model.answer;
            userAccount.Mobile = model.phone;
            userAccount.Question = model.question;
            userAccount.UserHguid = Guid.NewGuid().ToString();
            userAccount.UserName = model.username;
            userAccount.UserPassword = EncryptionHelper.MD5Encrypt64(model.password);
            userAccount.UserRoleId = (int)EnumUserRole.User;
            userAccount.UserHguid = GuidUtils.ToClearLow(GuidUtils.ClearLow);
            userAccount.UserEmail = model.email;
            _userService.InsertUser(userAccount);
            return Json(new SuccessResult { status = 1, data = "OK", msg = "注册成功" });
        }

        public ActionResult UserCenter()
        {
            CurrentUser currentUser = (CurrentUser)base.HttpContext.Session["CurrentUser"];
            UserAccount userAccount = _userService.GetUserByUserId(currentUser.UserId);
            return View(userAccount);
        }
        
        public ActionResult UserCenterUpdate()
        {
            CurrentUser currentUser = (CurrentUser)base.HttpContext.Session["CurrentUser"];
            UserAccount userAccount = _userService.GetUserByUserId(currentUser.UserId);
            return View(userAccount);
        }
        [HttpPost]
        public ActionResult UserCenterUpdate(RegisterModel model)
        {
            CurrentUser currentUser = (CurrentUser)base.HttpContext.Session["CurrentUser"];
            UserAccount userAccount = _userService.GetUserByUserId(currentUser.UserId);
            userAccount.Mobile = model.phone;
            userAccount.UserEmail = model.email;
            userAccount.Question = model.question;
            userAccount.Answer = model.answer;
            _userService.UpdateUser(userAccount);
            return Json(new SuccessResult { status = 1, data = "OK", msg = "OK" });
        }

        #region 忘记密码
        [AllowAnonymous]
        public ActionResult UserPassReset()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult ForgetGetQuestion(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return Json(new SuccessResult { status = 2, msg = "Error", data = "请输入用户名" });
            }
            UserAccount userAccount = _userService.GetUserByUserName(username);
            if (userAccount == null)
            {
                return Json(new SuccessResult { status = 2, msg = "Error", data = "输入的用户名不存在" });
            }
            return Json(new SuccessResult { status = 1, msg = "OK", data = userAccount.Question });
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult ForgetCheckAnswer(string username,string question,string answer)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(question) || string.IsNullOrEmpty(answer))
            {
                return Json(new SuccessResult { status = 2, msg = "Error", data = "参数错误" });
            }
            UserAccount userAccount = _userService.GetUserByUserName(username);
            if (userAccount == null)
            {
                return Json(new SuccessResult { status = 2, msg = "Error", data = "输入的用户名不存在" });
            }
            if (!userAccount.Answer.Equals(answer))
            {
                return Json(new SuccessResult { status = 2, msg = "Error", data = "请输入密保问题答案" });
            }
            token = GuidUtils.ToClearLow(GuidUtils.ClearLow);
            return Json(new SuccessResult { status = 1, msg = "OK", data = token });
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult ForgetResetPpassword(string username,string passwordNew,string forgetToken)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(passwordNew) 
                || string.IsNullOrEmpty(forgetToken) || !forgetToken.Equals(token))
            {
                return Json(new SuccessResult { status = 2, msg = "Error", data = "参数错误" });
            }
            UserAccount userAccount = _userService.GetUserByUserName(username);
            if (userAccount == null)
            {
                return Json(new SuccessResult { status = 2, msg = "Error", data = "输入的用户名不存在" });
            }
            userAccount.UserPassword = EncryptionHelper.MD5Encrypt64(passwordNew);
            _userService.UpdateUser(userAccount);
            return Json(new SuccessResult { status = 1, msg = "OK", data = "OK" });
        }
        #endregion



        public ActionResult UserPassUpdate()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            var context = base.HttpContext;
            #region Cookie
            HttpCookie myCookie = context.Request.Cookies["CurrentUser"];
            if (myCookie != null)
            {
                myCookie.Expires = DateTime.Now.AddMinutes(-1);//设置过期
                context.Response.Cookies.Add(myCookie);
            }
            #endregion

            #region Session
            var sessionUser = context.Session["CurrentUser"];
            if (sessionUser != null && sessionUser is CurrentUser)
            {
                CurrentUser currentUser = (CurrentUser)context.Session["CurrentUser"];
            }
            context.Session["CurrentUser"] = null; //表示将制定的键的值清空，并释放掉
            context.Session.Remove("CurrentUser");
            context.Session.Clear();//表示将会话中所有的session的键值都清空，但是session还是依然存在
            context.Session.RemoveAll();
            context.Session.Abandon(); //就是把当前Session对象删除了，下一次就是新的Session了
            #endregion
            return View("~/");
        }

        #region 进行的一些异步验证
        [HttpPost]
        public JsonResult CheckValid(string type,string str)
        {
            if (type.Equals("username"))  //验证用户名是否存在
            {
                UserAccount user = _userService.GetUserByUserName(str);
                if (user != null)
                {
                    return Json(new SuccessResult { status = 2, data = "OK", msg = "该用户名已存在" });
                }
                return Json(new SuccessResult { status = 1, data = "OK", msg = "OK" });
            }
            return Json(new SuccessResult { status = 2, data = "Data Error", msg = "Data Error" });
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Utility
{
    /// <summary>
    /// 自定义权限认证特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private string _loginUrl = null;

        public CustomAuthorizeAttribute(string loginUrl = "~/UserAccount/Login")
        {
            _loginUrl = loginUrl;
        }

        /// <summary>
        /// 方法会发生在Action之前
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var context = filterContext.HttpContext;
            if (filterContext.ActionDescriptor.IsDefined(typeof(CustomAllowAnonymousAttribute),true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(CustomAllowAnonymousAttribute),true))
            {
                return; //支持匿名，就啥也不干，继续执行action
            }
            else if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return; //支持匿名，就啥也不干，继续执行action
            }
            else if (context.Session["CurrentUser"] != null && context.Session["CurrentUser"] is CurrentUser)
            {
                return; //用户登录了，继续执行Action
            }
            else
            {
                if (context.Request.IsAjaxRequest())
                {
                    SuccessResult successResult = new SuccessResult()
                    {
                        status = 0,
                        data = "No Login",
                        msg = "没有登录，无权访问"
                    };
                    context.Session["CurrentUrl"] = context.Request.Url;
                    filterContext.Result = new JsonResult()
                    {
                        Data = successResult
                    };
                }
                else
                {
                    //跳转登录页面 短路器--停止当前流程，去别的执行流程
                    filterContext.Result = new RedirectResult(_loginUrl);
                    
                }
            }
            //base.OnAuthorization(filterContext);
        }
    }
    public sealed class CustomAllowAnonymousAttribute : Attribute
    {

    }
}
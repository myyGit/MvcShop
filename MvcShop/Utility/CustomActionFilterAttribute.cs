using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Utility
{
    /// <summary>
    /// 方法的filter：Action前 Action后   result前 result后
    /// </summary>
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //filterContext.HttpContext.Request.UserAgent
            //filterContext.Result=
            filterContext.HttpContext.Response.Write($"<h1 style='color:#00f'>这里是OnActionExecuting :{DateTime.Now.ToString("yyyyMMdd - HHmmss.fff")}</h1><hr>");
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"<h1 style='color:#00f'>这里是OnActionExecuted :{DateTime.Now.ToString("yyyyMMdd - HHmmss.fff")}</h1><hr>");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<h1 style='color:#00f'>这里是OnResultExecuting</h1><hr>");
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write($"<h1 style='color:#00f'>这里是OnResultExecuted :{DateTime.Now.ToString("yyyyMMdd - HHmmss.fff")}</h1><hr>");
        }
    }
}
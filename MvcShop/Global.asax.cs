using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using System.Configuration;
using System.Reflection;
using Autofac.Core;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using MvcShop.Service;
using MvcShop.Entity;

namespace MvcShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //注册Service
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
#pragma warning disable CS0618 // 类型或成员已过时
            builder.RegisterType<UserService>().As<IUserService>().InstancePerHttpRequest();
            builder.RegisterType<GoodService>().As<IGoodService>().InstancePerHttpRequest();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerHttpRequest();
#pragma warning restore CS0618 // 类型或成员已过时
            #region 链接
            builder.Register<IDbContext>(p => new MvcShopContext(ConfigurationManager.AppSettings["CoreConString"].ToString())).Named<IDbContext>("coreConString");
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>))
               .WithParameter(ResolvedParameter.ForNamed<IDbContext>("coreConString"))
               .InstancePerHttpRequest();
            #endregion
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));  //注册MVC容器
            System.Net.ServicePointManager.DefaultConnectionLimit = 512;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
        }
        /// <summary>
        /// https专用 防止报SSL/TLS 安全通道建立信任关系
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {   // 总是接受  
            return true;
        }
    }
}

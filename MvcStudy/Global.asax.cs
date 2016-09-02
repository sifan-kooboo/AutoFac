using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using MvcStudy.Controllers;

namespace MvcStudy
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);



            ContainerBuilder builder = new ContainerBuilder();
            //可以注册一个指定控制器
            //builder.RegisterType<HomeController>();
            //也可以一次注册一个程序集的所有控制器
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            

            builder.RegisterType<SqlDatabase>().As<IDatabase>();

          
                

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}

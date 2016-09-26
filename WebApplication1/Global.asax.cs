using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

namespace WebApplication1
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
           builder.RegisterControllers(Assembly.GetExecutingAssembly());
           builder.RegisterType<WebApplication1.Service.Test>().As<WebApplication1.IService.ICommon>();

           var container = builder.Build();
           DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}

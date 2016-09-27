using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using AutoFacMVC.Services;
using AutoFacMVC.IServices;
using System.Reflection;
using System.Web.Mvc;

namespace AutoFacMVC.App_Start
{
    public class DIConfig
    {
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TestService>().As<ITestService>();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
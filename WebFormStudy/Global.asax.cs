using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Autofac;
using Autofac.Integration.Web;

namespace WebFormStudy
{
    public class Global : HttpApplication,IContainerProviderAccessor
    {

        //声明一个静态IContainerProvider变量
        //提供全局Autofac Containers 在ASP.NET application生命周期当中。
        static IContainerProvider _containerProvider;

        
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            #region 我们添加的代码
            var builder = new ContainerBuilder();
            //注册将被通过反射创建的组件
            builder.RegisterType<DatabaseManager>();
            builder.RegisterType<OracleDatabase>().As<IDatabase>();
            builder.RegisterType<Test>();
            _containerProvider = new ContainerProvider(builder.Build());
            #endregion
        }
    }
}
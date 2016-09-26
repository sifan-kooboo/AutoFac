using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutofacTestPro1.Startup))]
namespace AutofacTestPro1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoFacMVC.Startup))]
namespace AutoFacMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

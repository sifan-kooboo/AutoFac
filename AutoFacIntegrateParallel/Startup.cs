using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoFacIntegrateParallel.Startup))]
namespace AutoFacIntegrateParallel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

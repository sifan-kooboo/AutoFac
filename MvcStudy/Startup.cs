using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcStudy.Startup))]
namespace MvcStudy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

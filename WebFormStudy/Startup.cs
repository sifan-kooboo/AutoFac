using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormStudy.Startup))]
namespace WebFormStudy
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

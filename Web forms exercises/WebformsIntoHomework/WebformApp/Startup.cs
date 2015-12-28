using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebformApp.Startup))]
namespace WebformApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoCSVHelper.Startup))]
namespace DemoCSVHelper
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

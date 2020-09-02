using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopBridge.Web.Startup))]
namespace ShopBridge.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

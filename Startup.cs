using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Market_Shop.Startup))]
namespace Market_Shop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

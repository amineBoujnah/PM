using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Terabyte.Web.Startup))]
namespace Terabyte.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

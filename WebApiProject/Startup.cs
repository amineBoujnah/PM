using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApiProject.Startup))]
namespace WebApiProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

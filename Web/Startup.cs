using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.Startup))]

namespace Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}

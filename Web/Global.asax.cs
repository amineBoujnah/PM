//using Web.ProfileAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Configuration;
using Stripe;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var secretKey = WebConfigurationManager.AppSettings["StripeSecretKey"];
            StripeConfiguration.SetApiKey(secretKey);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //AutoMapperWebProfile.Run();
        }
    }
}

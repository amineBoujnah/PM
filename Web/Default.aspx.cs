using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace Web
{
    public partial class Default : System.Web.UI.Page
    {
        public string stripePublishableKey = WebConfigurationManager.AppSettings["StripePublishableKey"];
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
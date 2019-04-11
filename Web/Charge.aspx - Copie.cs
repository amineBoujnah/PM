using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stripe;

namespace Web
{
    public partial class Charge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["stripeToken"] != null)
            {
                var customers = new CustomerService();
                var charges = new ChargeService();

                var customer = customers.Create(new CustomerCreateOptions
                {
                    Email = Request.Form["stripeEmail"],
                    SourceToken = Request.Form["stripeToken"]
                });

                var charge = charges.Create(new ChargeCreateOptions
                {
                    Amount = 5000,
                    Description = "Sample Charge",
                    Currency = "usd",
                    CustomerId = customer.Id
                });

                Console.WriteLine(charge);
               
                Response.Redirect("/DepotFront");
            }
        }
    }
}
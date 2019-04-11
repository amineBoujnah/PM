using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.PayPal;

namespace Web.Controllers
{
    public class PayPalController : Controller
    {
        // GET: PayPal
        public ActionResult Index()
        {
            TempData["succesPaiement"] = "Juste Bech ntesti bih mbaad fel Vue";
            //Show notification after paymment
            return View();
        }

        public ActionResult Success()
        {
            ViewBag.result = PDTHolder.Success(Request.QueryString.Get("tx"));
            return View("Success");
        }


    }
}
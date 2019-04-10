using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Terabyte.Web.Controllers
{
    public class CommunicationController : Controller
    {
        // GET: Communication
        public ActionResult Index()
        {
            return View();
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult Form(string receiverEmail, string subject, string message)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    var senderEmail = new System.Net.Mail.MailAddress("r.dinaabid@gmail.com", "Demo text");
                    var receiveremail = new System.Net.Mail.MailAddress(receiverEmail, "Receiver");
                    var password = "Papa300654";
                    var sub = "subject";
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)


                    };

                    using (var mess = new MailMessage(senderEmail, receiveremail)
                    {
                        Subject = subject,
                        Body = body
                    }

                )
                    {
                        smtp.Send(mess);
                    }


                    return View();
                }
            }

            catch (Exception)
            {

                ViewBag.Error = "there are same problem in sending mail";


            }

            return View();
        }
    }
}

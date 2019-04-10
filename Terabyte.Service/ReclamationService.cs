using SERVICE.PATTERN;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Terabyte.Data.Infrastructure;
using Terabyte.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Terabyte.Service;
using Terabyte.Data;
using Terabyte.Domain.Entities;
using System.Data.SqlClient;

using System.Collections.Specialized;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace Terabyte.Service
{
    public class ReclamationService : Service<Complaint>, IReclamationService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);

        public ReclamationService() : base(utk)
        {

        }
        public IEnumerable<Complaint> SearchRecBystat(string searchString)
        {
            IEnumerable<Complaint> RecDomain = GetMany();
            if (!String.IsNullOrEmpty(searchString))
            {
                RecDomain = GetMany(x => x.status.Contains(searchString));
            }
            return RecDomain;
        }

        public bool SendEmail(string toEmail, string subject, string emailBody)
        {
            try
            {
                string senderEmail = "amineboujnah1@gmail.com";
                string senderPassword = "Amine123";
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);



                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }



        public void sendSMS(string msg)
        {

            String result;
            string apiKey = "ReGj3gyB4qs-rF6uFX2t6Eoo8nCeuau24AjP4yxhbi";
            string numbers = "+21620074476"; // in a comma seperated list
                                             // string message = "A new Reclamation has come : Project : "+comp.ResourceName+" Status : "+comp.status+" Type : "+comp.ComplaintType;
            string sender = "Reclam sender";

            String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + msg + "&sender=" + sender;
            //refer to parameters to complete correct url string

            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

            objRequest.Method = "POST";
            objRequest.ContentLength = System.Text.Encoding.UTF8.GetByteCount(url);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(url);
            }
            catch (Exception e)
            {

            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }


        }


        public List<Complaint> getMandates()
        {
            IEnumerable<Complaint> m = (from complaints in utk.GetRepositoryBase<Complaint>().GetAll()
                                      select complaints);
            List<Complaint> list = m.ToList<Complaint>();
            return list;
        }
    }
}

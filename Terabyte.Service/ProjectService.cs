using SERVICE.PATTERN;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using Terabyte.Data.Infrastructure;
using Terabyte.Domain.Entities;

namespace Terabyte.Service
{
    public class ProjectService:Service<Project>,IProjectService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public ProjectService() : base(utk) { }

        //Recherche

        public bool SendEmail(string toEmail, string subject, string emailBody)
        {
            try
            {
                string senderEmail = "rabebdina.abid@esprit.tn";
                string senderPassword = "173jft0500";
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
        public IEnumerable<Project> SearchProjectByName(string searchString)
        {
            IEnumerable<Project> ProjectDomain = GetMany();
            if (!String.IsNullOrEmpty(searchString))
            {
                ProjectDomain = GetMany(x => x.Name.Contains(searchString));
            }
            return ProjectDomain;
        }
    }
}

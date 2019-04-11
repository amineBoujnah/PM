using SERVICE.PATTERN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terabyte.Domain.Entities;

namespace Terabyte.Service
{
   public interface IReclamationService:IService<Complaint>
    {
        IEnumerable<Complaint> SearchRecBystat(string searchString);
        void sendSMS(string msg);
        bool SendEmail(string toEmail, string subject, string emailBody);
    }
}


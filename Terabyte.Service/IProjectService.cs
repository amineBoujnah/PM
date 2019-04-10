using SERVICE.PATTERN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terabyte.Domain.Entities;

namespace Terabyte.Service
{
   public interface IProjectService:IService<Project>
    {
        IEnumerable<Project> SearchProjectByName(string searchString);
       bool SendEmail(string toEmail, string subject, string emailBody);
    }
}

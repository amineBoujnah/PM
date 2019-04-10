using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Terabyte.Domain.Entities;

namespace Terabyte.Web.Models
{
    public class EventVM
    {
        public int EventID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime? Start { get; set; }
        public DateTime End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }
        /*public int UserId { get; set; }
       
        public virtual User user { get; set; }*/
    }
}
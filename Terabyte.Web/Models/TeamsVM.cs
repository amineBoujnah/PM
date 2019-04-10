using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Terabyte.Domain.Entities;

namespace Terabyte.Web.Models
{
    public enum SpecialtyVM
    {
        DotNET,
        WEB,
        JEE,
        other
    }
    
       
   
    public class TeamsVM
    {
        
        public int TeamId { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public SpecialtyVM specialty { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Project> projects { get; set; }
    }
}
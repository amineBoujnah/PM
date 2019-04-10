using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Terabyte.Domain.Entities;

namespace Terabyte.Web.Models

{
    public enum CategoryVM
    {
        Cloud,
        Securite,
        Dev,
        BI,
        other
    
    } 
    public class ProjectVM
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public CategoryVM Category { get; set; } //enumeration
        public int Progress { get; set; }
        public int TeamId { get; set; }
       
        public virtual Team team { get; set; }
        public virtual ICollection<Tache> tasks { get; set; }
    }
}
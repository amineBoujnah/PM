using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum Category
{
    other
}
namespace Terabyte.Domain.Entities
{
    public class Project
    {
      
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; } //enumeration
        public int Progress { get; set; }
        public int? TeamId { get; set; }
        [ForeignKey("TeamId ")]
        public virtual Team team { get; set; }
        public virtual ICollection<Tache> tasks { get; set; }
    }
}

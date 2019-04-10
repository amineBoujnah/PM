
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


public enum Role 
{
    Team_Leader,
    Member,

}
namespace Terabyte.Domain.Entities
{
   public class User : Account
    {

         public string firstname { get; set; }
         public string lastname { get; set; }

         public string domain { get; set; }
         public DateTime DateOfBirth { get; set; }
         
         public string image { get; set; }
         public Role role { get; set; }
         
         public int? TeamId { get; set; }
         [ForeignKey("TeamId ")]
         public virtual Team team { get; set; }
         public virtual ICollection<Tache> tasks { get; set; }

         public int? specialityId { get; set; }
         [Required]
         [ForeignKey("specialityId ")]
         public virtual Specialty specialty { get; set; }

         
        
         

         public virtual ICollection<Logs> logs { get; set; }
         public virtual ICollection<Event> events { get; set; }

        

    }
}

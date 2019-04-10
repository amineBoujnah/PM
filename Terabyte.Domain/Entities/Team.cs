using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Domain.Entities
    
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public Specialty specialty { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Project> projects { get; set; }

    }
}

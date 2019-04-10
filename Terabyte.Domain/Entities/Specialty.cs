using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Domain.Entities
{
   public class Specialty
    {
        [Key]
        public int specialityId { get; set; }
        public string title { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}

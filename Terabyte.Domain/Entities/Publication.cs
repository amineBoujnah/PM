using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Domain.Entities
{
   public class Publication
    {
        [Key]
        public int PublicationId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public DateTime creationDate { get; set; }

        public int OwnerId { get; set; }
        [Required]
        [ForeignKey("OwnerId ")]
        public virtual Account Owner { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Domain.Entities
{
   public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public int UserId { get; set; }
        [Required]
        [ForeignKey("UserId ")]
        public virtual User user { get; set; }
    }
}

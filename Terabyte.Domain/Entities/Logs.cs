using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Domain.Entities
{
    public class Logs
    {   [Key]
        public int LogsId { get; set; }
        public int? UserId { get; set; }
        [Required]
        [ForeignKey("UserId ")]
        public virtual User user { get; set; }
    }
}

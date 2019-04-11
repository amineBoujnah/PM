using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Domain.Entities
{
   public class Complaint
    {

        [Key]
        public int ComplaintId { get; set; }
        
        [Display(Name = "Comment")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "this field is required")]
        public string Comment { get; set; }
        public DateTime DateReclamation { get; set; }
        public int? ClientId { get; set; }//nullable

        public string ComplaintType { get; set; }

        public string status { get; set; }
        public string ResourceName { get; set; }//nullable
    }
}

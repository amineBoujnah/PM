using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiProject.Models
{
   public class ReclamVF
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ComplaintId { get; set; }

        public string Comment { get; set; }
        public DateTime DateReclamation { get; set; }
        public int? ClientId { get; set; }//nullable

        public string ComplaintType { get; set; }

        public string status { get; set; }
        public string ResourceName { get; set; }//nullable


    }
}
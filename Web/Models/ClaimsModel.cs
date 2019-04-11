using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ClaimsModel
    {
     
        public int idReclamation { get; set; }

        [Required(ErrorMessage = "*Champs Obligatoire")]

        public string categorie { get; set; }
        [Required(ErrorMessage = "*Champs Obligatoire")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]

        public DateTime? dateReclamation { get; set; }
        [Required(ErrorMessage = "*Champs Obligatoire")]

        public string description { get; set; }
        [Required(ErrorMessage = "*Champs Obligatoire")]


        public string objet { get; set; }
        [Required(ErrorMessage = "*Champs Obligatoire")]


        public string status { get; set; }
        [Required(ErrorMessage = "*Champs Obligatoire")]


        public int? adherent_idAdherent { get; set; }
    }
}
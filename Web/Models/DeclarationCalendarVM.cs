using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class DeclarationCalendarVM
    {
        public string DTYPE { get; set; }
    
        public int idDeclaration { get; set; }
        
        public string titre { get; set; }
        
        public DateTime DateDeclaration { get; set; }

        public string fichier { get; set; }
    }
}
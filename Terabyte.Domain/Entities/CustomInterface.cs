using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Domain.Entities
{
   public class CustomInterface
    {
        [Key]
        public int InterfaceId { get; set; }
        public string Color { get; set; }
        public string Logo { get; set; }
        public string welcomeText { get; set; }
        /*public int DirectoId { get; set; }

        [ForeignKey("DirectoId ")]

        public virtual Director director { get; set; }*/


    }
}

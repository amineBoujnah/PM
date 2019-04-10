using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Domain.Entities
{
    public class Director : Account
    {
        public string firstname { get; set; }
        public string lastname { get; set; }

        public string domain { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string image { get; set; }
        public string role = "Director";
        public int? PackId { get; set; }

        [ForeignKey("PackId ")]
        public virtual Pack pack { get; set; }
        public int InterfaceId { get; set; }

        [ForeignKey("InterfaceId ")]

        public virtual CustomInterface userInterface { get; set; }
    }
}

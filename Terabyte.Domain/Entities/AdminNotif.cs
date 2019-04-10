using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Domain.Entities
{
   public class AdminNotif
    {
        [Key]
        public int Id { get; set; }
        public string msg { get; set; }
        public DateTime Datenotif { get; set; }
        public string username { get; set; }
        public string userid { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Domain.Entities
{
    public class Pack
    {
        [Key]
        public int PackId { get; set; }
        public float price { get; set; }
        public int NbClient { get; set; }
        public virtual ICollection<Director> Directors { get; set; }
    }
}

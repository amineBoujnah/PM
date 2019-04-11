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
        [Required, MaxLength(100), Display(Name = "Name")]
        public string PackName { get; set; }
        [Required, MaxLength(10000), Display(Name = "Pack Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
        //[Required, MaxLength(10000), Display(Name = "image"), DataType(DataType.MultilineText)]
        public string ImagePath { get; set; }
       // [Required, MaxLength(10000), Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        public int NbClient { get; set; }
       // public virtual ICollection<Director> Directors { get; set; }
    }
    }


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum State
{To_Do,Doing,Done

}
public enum Complexity
{
    Low,Medium,Hight
}
namespace Terabyte.Domain.Entities
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public String name { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public State state { get; set; }
        public Complexity complexity { get; set; }
        public int priority { get; set; }
        public int progress { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId ")]
        public virtual User user { get; set; }

        public int? ProjectId { get; set; }
        [ForeignKey("ProjectId ")]
        public virtual Project project { get; set; }



    }
}

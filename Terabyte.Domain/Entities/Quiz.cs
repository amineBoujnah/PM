using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Domain.Entities
{
   public partial  class Quiz
    {
       [Key]
        public int QuizID { get; set; }
        public string QuizName { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}

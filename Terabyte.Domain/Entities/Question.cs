using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Domain.Entities
{
   public partial class Question
    {
        [Key]
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public int? QuizID { get; set; }   
        [ForeignKey("QuizID")]
        public virtual Quiz Quiz { get; set; }
        public virtual ICollection<Answer> answers { get; set; }
    }
}

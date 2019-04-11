using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Domain.Entities
{
   public partial class Answer
    {
        [Key]
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }
        public bool isCorrect { get; set; }
        public int? QuestionID { get; set; }
        [ForeignKey("QuestionID")]
        public virtual Question Question { get; set; }
    }
}

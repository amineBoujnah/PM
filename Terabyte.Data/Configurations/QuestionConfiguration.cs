using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terabyte.Domain.Entities;

namespace Terabyte.Data.Configurations
{
    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            HasOptional(e => e.Quiz).WithMany(z => z.Questions).HasForeignKey(z => z.QuizID).WillCascadeOnDelete(true);
            HasMany(z => z.answers).WithOptional(a => a.Question).HasForeignKey(z => z.QuestionID).WillCascadeOnDelete(true);
        }
    }
}

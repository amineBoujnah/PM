using SERVICE.PATTERN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terabyte.Data.Infrastructure;
using Terabyte.Domain.Entities;

namespace Terabyte.Service
{
   public class QuestionService : Service<Question>, IQuestionService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public QuestionService():base(utk)
        {



        }
    }
}

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
    public class AnswerService : Service<Answer>, IAnswerService
    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public AnswerService():base(utk)
        {



        }
    }
}

using SERVICE.PATTERN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terabyte.Domain.Entities;
using Terabyte.Data.Infrastructure;

using System.Linq.Expressions;

namespace Terabyte.Service
{
    public class CustomInterfaceService : Service<Terabyte.Domain.Entities.CustomInterface>
    {
       
        static IDatabaseFactory Factory = new DatabaseFactory();//l'usine de fabrication du context
        static IUnitOfWork utk = new UnitOfWork(Factory);//unité de travail a besoin du factory pour communiquer avec la base

        public CustomInterfaceService() : base(utk)
        {
        }

        public CustomInterfaceService(IUnitOfWork utk) : base(utk)
        {
        }

      
      

       
    }
}

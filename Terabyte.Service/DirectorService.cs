using SERVICE.PATTERN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terabyte.Data.Infrastructure;
using Terabyte.Domain.Entities;
using Terabyte.Service;

namespace Terabyte.Service
{
    class DirectorService: Service<Director>, IDirector
    {

        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public DirectorService():base(utk)
        {



        }

        public Director countMaxPoints()
        {
            int nbMAX = GetMany().Max(e => e.NbPoint);
            var obj = Get(x => x.NbPoint == nbMAX);


            return obj;
        }


        public void AddDirector(Director d)
        {
            utk.GetRepositoryBase<Director>().Add(d);
            utk.Commit();
        }

        public List<Director> GetDirectortBypackID(int Idp)
        {
            return GetMany(t => t.PackId == Idp).ToList();
        }

        public Director GetDeByID(int IdDirector)
        {
            return null;// utk.GetRepositoryBase<Director>().GetById();
        }

       
    }
}

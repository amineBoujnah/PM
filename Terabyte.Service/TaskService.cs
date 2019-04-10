using SERVICE.PATTERN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terabyte.Data.Infrastructure;
using Terabyte.Domain.Entities;

namespace Terabyte.Service
{
    public class TaskService:Service<Tache>,ITaskService

    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public TaskService() : base(utk)
        {
        }
        public void Commit()
        {
            utk.Commit();
        }

        //public void CreateTache(Tache t)
        //{
        //    utk.getRepository<Pack>().Add(p);
        //}

        public void Dispose()
        {
            utk.Dispose();
        }

        //Recherche
        //State
        public IEnumerable<Tache> SearchTasksByName(string searchString/*, string searchInt*/)
        {
            IEnumerable<Tache> TaskDomain = GetMany();
            if (!String.IsNullOrEmpty(searchString))
            {
                TaskDomain = GetMany(x => x.name.Contains(searchString));
            }
            //if (!String.IsNullOrEmpty(searchInt))
            //{
            //    TaskDomain=GetMany(x=>x.user.Contains)
            //}
            return TaskDomain;
        }

        public List<Tache> geTache()
        {
            IEnumerable<Tache> t = (from taches in utk.GetRepositoryBase<Tache>().GetAll()
                                   select taches);
            List<Tache> list = t.ToList<Tache>();
            return list;
        }



    }


}


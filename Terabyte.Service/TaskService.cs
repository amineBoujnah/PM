using SERVICE.PATTERN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terabyte.Data.Infrastructure;
using Terabyte.Domain.Entities;

namespace Terabyte.Service
{
    public class TaskService:Service<Task>,ITaskService

    {
        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public TaskService() : base(utk)
        {
        }
        //Recherche
        public IEnumerable<Task> SearchTasksByName(string searchString/*, string searchInt*/)
        {
            IEnumerable<Task> TaskDomain = GetMany();
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

    }

       
}


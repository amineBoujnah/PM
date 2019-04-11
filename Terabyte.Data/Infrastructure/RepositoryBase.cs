
using Terabyte.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Data.Infrastructure
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private IDatabaseFactory factory;
        private MyContext datacontext;
        private readonly IDbSet<T> dbset;
        public RepositoryBase(IDatabaseFactory factory)
        {
            this.factory = factory;
            dbset = DataContext.Set<T>();
        }
        protected MyContext DataContext { get
            {
                return datacontext = factory.DataContext;
            } }
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public void Delete(Expression<Func<T, bool>> condition)
        {
            foreach(T Obj in dbset.Where(condition).AsEnumerable())
                dbset.Remove(Obj);
        }

        public void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> condition)
        {
            return dbset.Where(condition).FirstOrDefault();
        }

        public T GetById(string id)
        {
            return dbset.Find(id);
        }

        public T GetById(int id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> condition, System.Linq.Expressions.Expression<Func<T, bool>> orderby)
        {
            IQueryable<T> query = dbset;
            if (condition != null) 
                query = query.Where(condition);
            if (orderby != null)
                query = query.OrderBy(orderby);

            return query.AsEnumerable();   
        }

        public void Update(T entity)
        {
            dbset.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }
        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
    }
}

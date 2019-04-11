

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Terabyte.Data.Infrastructure;

namespace SERVICE.PATTERN
{
   public class Service<T> where T : class
    {
        private IUnitOfWork utk;
        public Service(IUnitOfWork utk)
        {
            this.utk = utk;

        }
        public virtual void Add(T entity)
        {
            //  throw new NotImplementedException();
            utk.GetRepositoryBase<T>().Add(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> condition)
        {
            // throw new NotImplementedException();
            utk.GetRepositoryBase<T>().Delete(condition);
        }

        public virtual void Delete(T entity)
        {
            // throw new NotImplementedException();
            utk.GetRepositoryBase<T>().Delete(entity);
        }

        public virtual T Get(Expression<Func<T, bool>> condition)
        {
            // throw new NotImplementedException();
            return utk.GetRepositoryBase<T>().Get(condition);
        }

        public virtual T GetById(string id)
        {
            //throw new NotImplementedException();
            return utk.GetRepositoryBase<T>().GetById(id);
        }

        public virtual T GetById(int id)
        {
            //throw new NotImplementedException();
            return utk.GetRepositoryBase<T>().GetById(id);

        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orderBy = null)
        {
            // throw new NotImplementedException();
            return utk.GetRepositoryBase<T>().GetMany(condition, orderBy);

        }

        public virtual void Update(T entity)
        {
            utk.GetRepositoryBase<T>().Update(entity);
            // throw new NotImplementedException();

        }
        public void Commit()
        {
            try
            {
                utk.Commit();
            }
            catch (Exception e) { throw; }

        }
        public void Dispose()
        {
            utk.Dispose();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Data.Infrastructure
{
    public interface IRepositoryBase <T> where T:class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(Expression<Func<T,bool>> condition);
        T GetById(int id);
        T GetById(string id);
        void Delete(Expression<Func<T, bool>> condition);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> condition
            , Expression<Func<T, bool>> orderby);

        IEnumerable<T> GetAll();

    }
}

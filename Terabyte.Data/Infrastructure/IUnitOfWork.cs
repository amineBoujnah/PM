using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Data.Infrastructure
{
    public interface IUnitOfWork :IDisposable
    {
        void Commit();
        IRepositoryBase<T> GetRepositoryBase<T>() where T : class;

    }
}

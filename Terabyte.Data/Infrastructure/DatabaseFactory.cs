
using Terabyte.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {

        private MyContext datacontext;
        public DatabaseFactory()
        {
            datacontext = new MyContext();
        }
        public MyContext DataContext
        {
            get
            {
                return datacontext;
            }
        }
        protected override void DisposeCore()
        {
            if(DataContext!=null)
            DataContext.Dispose();
        }
    }
}

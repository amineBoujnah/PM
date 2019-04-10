using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terabyte.Data.Conventions
{
    public class Convention1:Convention
    {
        public Convention1()
        {
            //Properties<string>().Where(a => a.Name.Contains("Id")).Configure(a => a.IsKey());
            Properties<DateTime>().Configure(e => e.HasColumnType("datetime2"));
        }

    }
}

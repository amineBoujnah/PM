using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terabyte.Domain.Entities;

namespace Terabyte.Data.Configurations
{
    class DirectorConfiguration : EntityTypeConfiguration<Director>
    {
        public DirectorConfiguration()
        {
            HasRequired(p => p.pack).WithMany(s => s.Directors).HasForeignKey(q => q.PackId);
            
        }
    }
}

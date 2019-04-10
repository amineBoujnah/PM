using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terabyte.Domain.Entities;

namespace Terabyte.Data.Configurations
{
    class TeamConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {

            HasMany(p => p.Users).WithOptional(c => c.team)
                     .HasForeignKey(p => p.TeamId).WillCascadeOnDelete(true);


           
        }
    }
}

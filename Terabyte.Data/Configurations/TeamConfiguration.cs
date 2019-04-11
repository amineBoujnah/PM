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

            HasMany(p => p.Users).WithRequired(c => c.team)
                     .HasForeignKey(p => p.TeamId).WillCascadeOnDelete(false);


            HasMany(p => p.projects).WithMany(c => c.teams)
                    .Map(m =>
                    {
                        m.ToTable("Jobs");
                        m.MapLeftKey("Project");
                        m.MapRightKey("Team");
                    });
        }
    }
}

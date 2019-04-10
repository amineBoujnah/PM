using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terabyte.Domain.Entities;

namespace Terabyte.Data.Configurations
{
    class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            HasMany(p => p.tasks).WithOptional(p => p.project).HasForeignKey(p => p.ProjectId);
        }
    
    }
}

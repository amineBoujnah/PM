using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terabyte.Domain.Entities;

namespace Terabyte.Data.Configurations 
{
    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasMany(p => p.tasks).WithOptional(l => l.user).HasForeignKey(p => p.UserId).WillCascadeOnDelete(true);
            HasOptional(p => p.specialty).WithMany(s => s.Users).HasForeignKey(p => p.specialityId);
            HasMany(p => p.logs).WithOptional(p => p.user).HasForeignKey(p => p.UserId);
          
        }
    }
}

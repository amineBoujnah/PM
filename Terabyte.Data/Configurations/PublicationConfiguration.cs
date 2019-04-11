using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terabyte.Domain.Entities;

namespace Terabyte.Data.Configurations
{
    class PublicationConfiguration : EntityTypeConfiguration<Publication>
    {
        public PublicationConfiguration()
        {
            HasRequired(p => p.Owner).WithMany(q => q.publications).HasForeignKey(p => p.OwnerId);

        }
    }
}

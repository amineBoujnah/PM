namespace Terabyte.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CommentPartial : DbContext
    {
        public CommentPartial()
            : base("name=CommentPartial")
        {
        }

        public virtual DbSet<CommentPar> Comments { get; set; }
        public virtual DbSet<ProjectVM> Projects { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

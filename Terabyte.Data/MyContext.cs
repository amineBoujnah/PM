

using System.Data.Entity;
using Terabyte.Data.Configurations;
using Terabyte.Data.Conventions;
using Terabyte.Domain.Entities;

namespace Terabyte.Data
{
    public class MyContext : DbContext
    {

        public MyContext() : base("name=Terabyte")
        {

        }
        public DbSet<CustomInterface> Interfaces { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Complaint> complaints { get; set; }
        public DbSet<AdminNotif> Anotifs { get; set; }
        //public DbSet<User> Users { get; set; }








        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Configurations.Add(new FilmConfiguration());
            modelBuilder.Conventions.Add(new Convention1());
            modelBuilder.Configurations.Add(new TeamConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new PublicationConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new DirectorConfiguration());
            modelBuilder.Configurations.Add(new ProjectConfiguration());
        }
    }
}

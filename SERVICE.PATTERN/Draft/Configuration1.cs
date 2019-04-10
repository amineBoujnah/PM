namespace Terabyte.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration1 : DbMigrationsConfiguration<Terabyte.Data.MyContext>
    {
        public Configuration1()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Terabyte.Data.MyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

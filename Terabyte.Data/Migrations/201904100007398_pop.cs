namespace Terabyte.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pop : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tasks", newName: "Taches");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Taches", newName: "Tasks");
        }
    }
}

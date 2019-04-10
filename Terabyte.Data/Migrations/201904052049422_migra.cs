namespace Terabyte.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migra : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Employes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        prenom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}

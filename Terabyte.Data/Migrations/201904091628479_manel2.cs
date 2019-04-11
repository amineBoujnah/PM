namespace Terabyte.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "PackId", "dbo.Packs");
            AddForeignKey("dbo.Accounts", "PackId", "dbo.Packs", "PackId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "PackId", "dbo.Packs");
            AddForeignKey("dbo.Accounts", "PackId", "dbo.Packs", "PackId", cascadeDelete: true);
        }
    }
}

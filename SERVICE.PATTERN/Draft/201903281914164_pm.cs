namespace Terabyte.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        End = c.DateTime(precision: 7, storeType: "datetime2"),
                        ThemeColor = c.String(),
                        IsFullDay = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CustomInterfaces",
                c => new
                    {
                        InterfaceId = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        Logo = c.String(),
                        welcomeText = c.String(),
                    })
                .PrimaryKey(t => t.InterfaceId);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogsId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.LogsId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        firstname = c.String(),
                        lastname = c.String(),
                        domain = c.String(),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        image = c.String(),
                        role = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        specialityId = c.Int(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specialties", t => t.specialityId)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.specialityId);
            
            CreateTable(
                "dbo.CustomUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Director_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Directors", t => t.Director_Id)
                .Index(t => t.UserId)
                .Index(t => t.Director_Id);
            
            CreateTable(
                "dbo.CustomUserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Int(nullable: false),
                        Director_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Directors", t => t.Director_Id)
                .Index(t => t.UserId)
                .Index(t => t.Director_Id);
            
            CreateTable(
                "dbo.Publications",
                c => new
                    {
                        PublicationId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        image = c.String(),
                        visibility = c.Int(nullable: false),
                        creationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        User_Id = c.Int(),
                        Director_Id = c.Int(),
                    })
                .PrimaryKey(t => t.PublicationId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Directors", t => t.Director_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Director_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Contenu = c.String(),
                        PublicationId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Publications", t => t.PublicationId)
                .Index(t => t.PublicationId);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Director_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Directors", t => t.Director_Id)
                .Index(t => t.UserId)
                .Index(t => t.Director_Id);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        specialityId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                    })
                .PrimaryKey(t => t.specialityId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        start_date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        end_date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        state = c.Int(nullable: false),
                        complexity = c.Int(nullable: false),
                        priority = c.Int(nullable: false),
                        progress = c.Int(nullable: false),
                        UserId = c.Int(),
                        ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        image = c.String(),
                        category = c.Int(nullable: false),
                        progress = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        image = c.String(),
                        specialty_specialityId = c.Int(),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Specialties", t => t.specialty_specialityId)
                .Index(t => t.specialty_specialityId);
            
            CreateTable(
                "dbo.Packs",
                c => new
                    {
                        PackId = c.Int(nullable: false, identity: true),
                        price = c.Single(nullable: false),
                        NbClient = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PackId);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        firstname = c.String(),
                        lastname = c.String(),
                        domain = c.String(),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        image = c.String(),
                        PackId = c.Int(nullable: false),
                        InterfaceId = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packs", t => t.PackId, cascadeDelete: true)
                .ForeignKey("dbo.CustomInterfaces", t => t.InterfaceId, cascadeDelete: true)
                .Index(t => t.PackId)
                .Index(t => t.InterfaceId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Project = c.Int(nullable: false),
                        Team = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project, t.Team })
                .ForeignKey("dbo.Teams", t => t.Project, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Team, cascadeDelete: true)
                .Index(t => t.Project)
                .Index(t => t.Team);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Directors", "InterfaceId", "dbo.CustomInterfaces");
            DropForeignKey("dbo.CustomUserRoles", "Director_Id", "dbo.Directors");
            DropForeignKey("dbo.Publications", "Director_Id", "dbo.Directors");
            DropForeignKey("dbo.Directors", "PackId", "dbo.Packs");
            DropForeignKey("dbo.CustomUserLogins", "Director_Id", "dbo.Directors");
            DropForeignKey("dbo.CustomUserClaims", "Director_Id", "dbo.Directors");
            DropForeignKey("dbo.Tasks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "specialty_specialityId", "dbo.Specialties");
            DropForeignKey("dbo.Jobs", "Team", "dbo.Projects");
            DropForeignKey("dbo.Jobs", "Project", "dbo.Teams");
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Users", "specialityId", "dbo.Specialties");
            DropForeignKey("dbo.CustomUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Publications", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "PublicationId", "dbo.Publications");
            DropForeignKey("dbo.Logs", "UserId", "dbo.Users");
            DropForeignKey("dbo.CustomUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Events", "User_Id", "dbo.Users");
            DropForeignKey("dbo.CustomUserClaims", "UserId", "dbo.Users");
            DropIndex("dbo.Jobs", new[] { "Team" });
            DropIndex("dbo.Jobs", new[] { "Project" });
            DropIndex("dbo.Directors", new[] { "InterfaceId" });
            DropIndex("dbo.Directors", new[] { "PackId" });
            DropIndex("dbo.Teams", new[] { "specialty_specialityId" });
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropIndex("dbo.Tasks", new[] { "UserId" });
            DropIndex("dbo.CustomUserRoles", new[] { "Director_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "PublicationId" });
            DropIndex("dbo.Publications", new[] { "Director_Id" });
            DropIndex("dbo.Publications", new[] { "User_Id" });
            DropIndex("dbo.CustomUserLogins", new[] { "Director_Id" });
            DropIndex("dbo.CustomUserLogins", new[] { "UserId" });
            DropIndex("dbo.CustomUserClaims", new[] { "Director_Id" });
            DropIndex("dbo.CustomUserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "specialityId" });
            DropIndex("dbo.Users", new[] { "TeamId" });
            DropIndex("dbo.Logs", new[] { "UserId" });
            DropIndex("dbo.Events", new[] { "User_Id" });
            DropTable("dbo.Jobs");
            DropTable("dbo.Directors");
            DropTable("dbo.Packs");
            DropTable("dbo.Teams");
            DropTable("dbo.Projects");
            DropTable("dbo.Tasks");
            DropTable("dbo.Specialties");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.Comments");
            DropTable("dbo.Publications");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Logs");
            DropTable("dbo.CustomInterfaces");
            DropTable("dbo.Events");
        }
    }
}

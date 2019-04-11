namespace Terabyte.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        AnswerText = c.String(),
                        isCorrect = c.Boolean(nullable: false),
                        QuestionID = c.Int(),
                    })
                .PrimaryKey(t => t.AnswerID)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        QuizID = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Quizs", t => t.QuizID, cascadeDelete: true)
                .Index(t => t.QuizID);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        QuizID = c.Int(nullable: false, identity: true),
                        QuizName = c.String(),
                    })
                .PrimaryKey(t => t.QuizID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        image = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Accounts", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        firstname = c.String(),
                        lastname = c.String(),
                        domain = c.String(),
                        DateOfBirth = c.DateTime(precision: 7, storeType: "datetime2"),
                        image = c.String(),
                        role = c.Int(),
                        TeamId = c.Int(),
                        specialityId = c.Int(),
                        idDirector = c.Int(),
                        firstname1 = c.String(),
                        lastname1 = c.String(),
                        domain1 = c.String(),
                        DateOfBirth1 = c.DateTime(precision: 7, storeType: "datetime2"),
                        image1 = c.String(),
                        PackId = c.Int(),
                        InterfaceId = c.Int(),
                        NbPoint = c.Int(),
                        Score = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packs", t => t.PackId, cascadeDelete: true)
                .ForeignKey("dbo.CustomInterfaces", t => t.InterfaceId, cascadeDelete: true)
                .ForeignKey("dbo.Specialties", t => t.specialityId)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.specialityId)
                .Index(t => t.PackId)
                .Index(t => t.InterfaceId);
            
            CreateTable(
                "dbo.CustomUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.CustomUserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Int(nullable: false),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogsId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.LogsId)
                .ForeignKey("dbo.Accounts", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Publications",
                c => new
                    {
                        PublicationId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        image = c.String(),
                        creationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PublicationId)
                .ForeignKey("dbo.Accounts", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.Packs",
                c => new
                    {
                        PackId = c.Int(nullable: false, identity: true),
                        price = c.Single(nullable: false),
                        PackName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        ImagePath = c.String(),
                        NbClient = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PackId);
            
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
                        ImageUrl = c.String(),
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
                .ForeignKey("dbo.Accounts", t => t.UserId, cascadeDelete: true)
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
            DropForeignKey("dbo.Events", "UserId", "dbo.Accounts");
            DropForeignKey("dbo.Tasks", "UserId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "specialty_specialityId", "dbo.Specialties");
            DropForeignKey("dbo.Jobs", "Team", "dbo.Projects");
            DropForeignKey("dbo.Jobs", "Project", "dbo.Teams");
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Accounts", "specialityId", "dbo.Specialties");
            DropForeignKey("dbo.Publications", "OwnerId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "InterfaceId", "dbo.CustomInterfaces");
            DropForeignKey("dbo.Accounts", "PackId", "dbo.Packs");
            DropForeignKey("dbo.CustomUserRoles", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.CustomUserLogins", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.CustomUserClaims", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Logs", "UserId", "dbo.Accounts");
            DropForeignKey("dbo.Questions", "QuizID", "dbo.Quizs");
            DropForeignKey("dbo.Answers", "QuestionID", "dbo.Questions");
            DropIndex("dbo.Jobs", new[] { "Team" });
            DropIndex("dbo.Jobs", new[] { "Project" });
            DropIndex("dbo.Teams", new[] { "specialty_specialityId" });
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropIndex("dbo.Tasks", new[] { "UserId" });
            DropIndex("dbo.CustomUserRoles", new[] { "Account_Id" });
            DropIndex("dbo.Publications", new[] { "OwnerId" });
            DropIndex("dbo.Logs", new[] { "UserId" });
            DropIndex("dbo.CustomUserLogins", new[] { "Account_Id" });
            DropIndex("dbo.CustomUserClaims", new[] { "Account_Id" });
            DropIndex("dbo.Accounts", new[] { "InterfaceId" });
            DropIndex("dbo.Accounts", new[] { "PackId" });
            DropIndex("dbo.Accounts", new[] { "specialityId" });
            DropIndex("dbo.Accounts", new[] { "TeamId" });
            DropIndex("dbo.Events", new[] { "UserId" });
            DropIndex("dbo.Questions", new[] { "QuizID" });
            DropIndex("dbo.Answers", new[] { "QuestionID" });
            DropTable("dbo.Jobs");
            DropTable("dbo.Teams");
            DropTable("dbo.Projects");
            DropTable("dbo.Tasks");
            DropTable("dbo.Specialties");
            DropTable("dbo.CustomInterfaces");
            DropTable("dbo.Packs");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.Publications");
            DropTable("dbo.Logs");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.Accounts");
            DropTable("dbo.Events");
            DropTable("dbo.Quizs");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}

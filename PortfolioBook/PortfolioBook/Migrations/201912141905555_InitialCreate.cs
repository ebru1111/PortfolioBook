namespace PortfolioBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhotoCommends",
                c => new
                    {
                        PhotoCommendID = c.Int(nullable: false, identity: true),
                        ApplicationUserID = c.String(maxLength: 128),
                        PhotoID = c.Int(nullable: false),
                        PhotographCommend = c.String(maxLength: 400),
                    })
                .PrimaryKey(t => t.PhotoCommendID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.Photos", t => t.PhotoID, cascadeDelete: true)
                .Index(t => t.ApplicationUserID)
                .Index(t => t.PhotoID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        ImageUrl = c.String(nullable: false, maxLength: 500),
                        AltText = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.PhotoID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        ApplicationUserID = c.String(maxLength: 128),
                        RealeseDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NumberOfPageViews = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.ProjectCommends",
                c => new
                    {
                        ProjectCommendID = c.Int(nullable: false, identity: true),
                        ApplicationUserID = c.String(maxLength: 128),
                        ProjectID = c.Int(nullable: false),
                        ProjectCommends = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.ProjectCommendID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ApplicationUserID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.ProjectStars",
                c => new
                    {
                        ProjectStarID = c.Int(nullable: false, identity: true),
                        ApplicationUserID = c.String(maxLength: 128),
                        ProjectID = c.Int(nullable: false),
                        Star = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectStarID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ApplicationUserID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PhotoCommends", "PhotoID", "dbo.Photos");
            DropForeignKey("dbo.Photos", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ProjectStars", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ProjectStars", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectCommends", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ProjectCommends", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.PhotoCommends", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProjectStars", new[] { "ProjectID" });
            DropIndex("dbo.ProjectStars", new[] { "ApplicationUserID" });
            DropIndex("dbo.ProjectCommends", new[] { "ProjectID" });
            DropIndex("dbo.ProjectCommends", new[] { "ApplicationUserID" });
            DropIndex("dbo.Projects", new[] { "ApplicationUserID" });
            DropIndex("dbo.Photos", new[] { "ProjectID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.PhotoCommends", new[] { "PhotoID" });
            DropIndex("dbo.PhotoCommends", new[] { "ApplicationUserID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProjectStars");
            DropTable("dbo.ProjectCommends");
            DropTable("dbo.Projects");
            DropTable("dbo.Photos");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.PhotoCommends");
        }
    }
}

namespace PracticeBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasePoses",
                c => new
                    {
                        BasePoseID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Info = c.String(),
                        TwoSided = c.Boolean(nullable: false),
                        ImageURL = c.String(),
                        DurationSuggestion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BasePoseID);
            
            CreateTable(
                "dbo.Practices",
                c => new
                    {
                        PracticeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Yogi_YogiID = c.Int(),
                    })
                .PrimaryKey(t => t.PracticeID)
                .ForeignKey("dbo.Yogis", t => t.Yogi_YogiID)
                .Index(t => t.Yogi_YogiID);
            
            CreateTable(
                "dbo.UserPoses",
                c => new
                    {
                        UserPoseID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Duration = c.Int(nullable: false),
                        PracticeOrder = c.Int(nullable: false),
                        Side = c.String(),
                        Reference_BasePoseID = c.Int(nullable: false),
                        Practice_PracticeID = c.Int(),
                    })
                .PrimaryKey(t => t.UserPoseID)
                .ForeignKey("dbo.BasePoses", t => t.Reference_BasePoseID, cascadeDelete: true)
                .ForeignKey("dbo.Practices", t => t.Practice_PracticeID)
                .Index(t => t.Reference_BasePoseID)
                .Index(t => t.Practice_PracticeID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                "dbo.Yogis",
                c => new
                    {
                        YogiID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BaseUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.YogiID)
                .ForeignKey("dbo.AspNetUsers", t => t.BaseUser_Id)
                .Index(t => t.BaseUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Practices", "Yogi_YogiID", "dbo.Yogis");
            DropForeignKey("dbo.Yogis", "BaseUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserPoses", "Practice_PracticeID", "dbo.Practices");
            DropForeignKey("dbo.UserPoses", "Reference_BasePoseID", "dbo.BasePoses");
            DropIndex("dbo.Yogis", new[] { "BaseUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UserPoses", new[] { "Practice_PracticeID" });
            DropIndex("dbo.UserPoses", new[] { "Reference_BasePoseID" });
            DropIndex("dbo.Practices", new[] { "Yogi_YogiID" });
            DropTable("dbo.Yogis");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UserPoses");
            DropTable("dbo.Practices");
            DropTable("dbo.BasePoses");
        }
    }
}

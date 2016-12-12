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
                "dbo.Yogis",
                c => new
                    {
                        YogiID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.YogiID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Practices", "Yogi_YogiID", "dbo.Yogis");
            DropForeignKey("dbo.UserPoses", "Practice_PracticeID", "dbo.Practices");
            DropForeignKey("dbo.UserPoses", "Reference_BasePoseID", "dbo.BasePoses");
            DropIndex("dbo.UserPoses", new[] { "Practice_PracticeID" });
            DropIndex("dbo.UserPoses", new[] { "Reference_BasePoseID" });
            DropIndex("dbo.Practices", new[] { "Yogi_YogiID" });
            DropTable("dbo.Yogis");
            DropTable("dbo.UserPoses");
            DropTable("dbo.Practices");
            DropTable("dbo.BasePoses");
        }
    }
}

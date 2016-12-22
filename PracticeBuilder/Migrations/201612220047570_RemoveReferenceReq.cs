namespace PracticeBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveReferenceReq : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserPoses", "Reference_BasePoseID", "dbo.BasePoses");
            DropIndex("dbo.UserPoses", new[] { "Reference_BasePoseID" });
            AlterColumn("dbo.UserPoses", "Reference_BasePoseID", c => c.Int());
            CreateIndex("dbo.UserPoses", "Reference_BasePoseID");
            AddForeignKey("dbo.UserPoses", "Reference_BasePoseID", "dbo.BasePoses", "BasePoseID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPoses", "Reference_BasePoseID", "dbo.BasePoses");
            DropIndex("dbo.UserPoses", new[] { "Reference_BasePoseID" });
            AlterColumn("dbo.UserPoses", "Reference_BasePoseID", c => c.Int(nullable: false));
            CreateIndex("dbo.UserPoses", "Reference_BasePoseID");
            AddForeignKey("dbo.UserPoses", "Reference_BasePoseID", "dbo.BasePoses", "BasePoseID", cascadeDelete: true);
        }
    }
}

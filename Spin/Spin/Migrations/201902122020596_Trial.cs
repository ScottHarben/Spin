namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoundModels", "CourseModelId", c => c.Int(nullable: false));
            AddColumn("dbo.RoundModels", "TeeModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.RoundModels", "CourseModelId");
            CreateIndex("dbo.RoundModels", "TeeModelId");
            AddForeignKey("dbo.RoundModels", "CourseModelId", "dbo.CourseModels", "Id", cascadeDelete: false);
            AddForeignKey("dbo.RoundModels", "TeeModelId", "dbo.TeeModels", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoundModels", "TeeModelId", "dbo.TeeModels");
            DropForeignKey("dbo.RoundModels", "CourseModelId", "dbo.CourseModels");
            DropIndex("dbo.RoundModels", new[] { "TeeModelId" });
            DropIndex("dbo.RoundModels", new[] { "CourseModelId" });
            DropColumn("dbo.RoundModels", "TeeModelId");
            DropColumn("dbo.RoundModels", "CourseModelId");
        }
    }
}

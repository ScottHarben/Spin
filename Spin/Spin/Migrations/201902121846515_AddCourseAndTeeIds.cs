namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddCourseAndTeeIds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoundModels", "TeeModelId", c => c.Int(nullable: false));
            AddColumn("dbo.RoundModels", "CourseModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.RoundModels", "TeeModelId");
            CreateIndex("dbo.RoundModels", "CourseModelId");
            AddForeignKey("dbo.RoundModels", "TeeModelId", "dbo.TeeModels", "Id", cascadeDelete: false);
            AddForeignKey("dbo.RoundModels", "CourseModelId", "dbo.CourseModels", "Id", cascadeDelete: false);
        }

        public override void Down()
        {
            DropForeignKey("dbo.RoundModels", "CourseModelId", "dbo.CourseModels");
            DropForeignKey("dbo.RoundModels", "TeeModelId", "dbo.TeeModels");
            DropIndex("dbo.RoundModels", new[] {"CourseModelId"});
            DropIndex("dbo.RoundModels", new[] {"TeeModelId"});
            DropColumn("dbo.RoundModels", "CourseModelId");
            DropColumn("dbo.RoundModels", "TeeModelId");
        }
    }
}

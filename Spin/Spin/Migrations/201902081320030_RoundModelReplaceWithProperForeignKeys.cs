namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoundModelReplaceWithProperForeignKeys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoundModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        CourseModelId = c.Int(nullable: false),
                        TeeModelId = c.Int(nullable: false),
                        HoleModelId = c.Int(nullable: false),
                        FairwayInRegulation = c.Boolean(nullable: false),
                        GreenInRegulation = c.Boolean(nullable: false),
                        NumberOfPutts = c.Byte(nullable: false),
                        StrokesAgainstPar = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseModels", t => t.CourseModelId, cascadeDelete: false)
                .ForeignKey("dbo.HoleModels", t => t.HoleModelId, cascadeDelete: false)
                .ForeignKey("dbo.TeeModels", t => t.TeeModelId, cascadeDelete: false)
                .Index(t => t.CourseModelId)
                .Index(t => t.TeeModelId)
                .Index(t => t.HoleModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoundModels", "TeeModelId", "dbo.TeeModels");
            DropForeignKey("dbo.RoundModels", "HoleModelId", "dbo.HoleModels");
            DropForeignKey("dbo.RoundModels", "CourseModelId", "dbo.CourseModels");
            DropIndex("dbo.RoundModels", new[] { "HoleModelId" });
            DropIndex("dbo.RoundModels", new[] { "TeeModelId" });
            DropIndex("dbo.RoundModels", new[] { "CourseModelId" });
            DropTable("dbo.RoundModels");
        }
    }
}

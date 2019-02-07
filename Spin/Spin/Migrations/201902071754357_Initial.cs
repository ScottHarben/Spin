namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeeModels", "CourseModelId", "dbo.CourseModels");
            DropForeignKey("dbo.HoleModels", "TeeModelId", "dbo.TeeModels");
            DropIndex("dbo.HoleModels", new[] { "TeeModelId" });
            DropIndex("dbo.TeeModels", new[] { "CourseModelId" });
            DropTable("dbo.CourseModels");
            DropTable("dbo.HoleModels");
            DropTable("dbo.TeeModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TeeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeeName = c.String(),
                        TeePar = c.Byte(nullable: false),
                        TeeDistance = c.Short(nullable: false),
                        TeeRating = c.Single(nullable: false),
                        TeeSlope = c.Byte(nullable: false),
                        CourseModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HoleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoleNumber = c.Byte(nullable: false),
                        HolePar = c.Byte(nullable: false),
                        HoleDistance = c.Short(nullable: false),
                        HoleHandicap = c.Byte(nullable: false),
                        TeeModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.TeeModels", "CourseModelId");
            CreateIndex("dbo.HoleModels", "TeeModelId");
            AddForeignKey("dbo.HoleModels", "TeeModelId", "dbo.TeeModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TeeModels", "CourseModelId", "dbo.CourseModels", "Id", cascadeDelete: true);
        }
    }
}

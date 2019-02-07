namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeeModelInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeeName = c.String(nullable: false),
                        TeePar = c.Byte(nullable: false),
                        TeeDistance = c.Short(nullable: false),
                        CourseModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseModels", t => t.CourseModelId, cascadeDelete: true)
                .Index(t => t.CourseModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeeModels", "CourseModelId", "dbo.CourseModels");
            DropIndex("dbo.TeeModels", new[] { "CourseModelId" });
            DropTable("dbo.TeeModels");
        }
    }
}

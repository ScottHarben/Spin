namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HoleModelInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HoleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoleNumber = c.Byte(nullable: false),
                        HolePar = c.Byte(nullable: false),
                        HoleDistance = c.Short(nullable: false),
                        TeeModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeeModels", t => t.TeeModelId, cascadeDelete: true)
                .Index(t => t.TeeModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoleModels", "TeeModelId", "dbo.TeeModels");
            DropIndex("dbo.HoleModels", new[] { "TeeModelId" });
            DropTable("dbo.HoleModels");
        }
    }
}

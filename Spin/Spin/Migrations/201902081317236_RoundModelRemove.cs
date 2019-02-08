namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoundModelRemove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoundModels", "CourseModel_Id", "dbo.CourseModels");
            DropForeignKey("dbo.RoundModels", "HoleModel_Id", "dbo.HoleModels");
            DropForeignKey("dbo.RoundModels", "TeeModel_Id", "dbo.TeeModels");
            DropIndex("dbo.RoundModels", new[] { "CourseModel_Id" });
            DropIndex("dbo.RoundModels", new[] { "HoleModel_Id" });
            DropIndex("dbo.RoundModels", new[] { "TeeModel_Id" });
            DropTable("dbo.RoundModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoundModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        TeeId = c.Int(nullable: false),
                        HoleId = c.Int(nullable: false),
                        FairwayInRegulation = c.Boolean(nullable: false),
                        GreenInRegulation = c.Boolean(nullable: false),
                        NumberOfPutts = c.Byte(nullable: false),
                        StrokesAgainstPar = c.Short(nullable: false),
                        CourseModel_Id = c.Int(),
                        HoleModel_Id = c.Int(),
                        TeeModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.RoundModels", "TeeModel_Id");
            CreateIndex("dbo.RoundModels", "HoleModel_Id");
            CreateIndex("dbo.RoundModels", "CourseModel_Id");
            AddForeignKey("dbo.RoundModels", "TeeModel_Id", "dbo.TeeModels", "Id");
            AddForeignKey("dbo.RoundModels", "HoleModel_Id", "dbo.HoleModels", "Id");
            AddForeignKey("dbo.RoundModels", "CourseModel_Id", "dbo.CourseModels", "Id");
        }
    }
}

namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoundModelBoolToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoundModels", "FairwayInRegulation", c => c.Int(nullable: false));
            AlterColumn("dbo.RoundModels", "GreenInRegulation", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoundModels", "GreenInRegulation", c => c.Boolean(nullable: false));
            AlterColumn("dbo.RoundModels", "FairwayInRegulation", c => c.Boolean(nullable: false));
        }
    }
}

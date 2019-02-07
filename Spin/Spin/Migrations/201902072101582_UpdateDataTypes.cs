namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StrokesAgainstParModels", "StrokesAgainstPar", c => c.Short(nullable: false));
            AlterColumn("dbo.RoundModels", "StrokesAgainstPar", c => c.Short(nullable: false));
            DropColumn("dbo.StrokesAgainstParModels", "ScoreAgainstPar");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StrokesAgainstParModels", "ScoreAgainstPar", c => c.Byte(nullable: false));
            AlterColumn("dbo.RoundModels", "StrokesAgainstPar", c => c.Int(nullable: false));
            DropColumn("dbo.StrokesAgainstParModels", "StrokesAgainstPar");
        }
    }
}

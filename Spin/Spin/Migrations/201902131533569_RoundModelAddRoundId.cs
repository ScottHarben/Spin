namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoundModelAddRoundId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoundModels", "RoundId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoundModels", "RoundId");
        }
    }
}

namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IEnumerableRoundModels : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RoundModels", "RoundId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoundModels", "RoundId", c => c.Long(nullable: false));
        }
    }
}

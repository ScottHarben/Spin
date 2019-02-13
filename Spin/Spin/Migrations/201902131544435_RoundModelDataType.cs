namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoundModelDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoundModels", "RoundId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoundModels", "RoundId", c => c.Int(nullable: false));
        }
    }
}

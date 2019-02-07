namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SAPPopulate : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO StrokesAgainstParModels (ScoreName, StrokesAgainstPar) Values" +
                "('Double Eagle', -3)," +
                "('Eagle', -2)," +
                "('Birdie', -1)," +
                "('Par', 0)," +
                "('Bogie', 1)," +
                "('Double Bogie', 2)," +
                "('Triple Bogie', 3)");
        }
        
        public override void Down()
        {
        }
    }
}

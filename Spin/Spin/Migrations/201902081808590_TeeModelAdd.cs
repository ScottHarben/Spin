namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeeModelAdd : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TeeModels (TeeName, TeePar, TeeDistance, CourseModelId) " +
                "VALUES ('Black', 72, 7027, 2), ('Burgandy', 72, 6547, 2), ('Blue', 72, 6069, 2)");
        }
        
        public override void Down()
        {
        }
    }
}

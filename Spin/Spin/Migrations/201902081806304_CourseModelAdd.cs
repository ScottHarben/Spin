namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseModelAdd : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CourseModels (CourseName) VALUES ('Atlanta National Golf Club')");
        }
        
        public override void Down()
        {
        }
    }
}

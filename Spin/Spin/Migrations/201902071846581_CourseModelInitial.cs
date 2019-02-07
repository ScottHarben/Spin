namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseModelInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CourseModels");
        }
    }
}

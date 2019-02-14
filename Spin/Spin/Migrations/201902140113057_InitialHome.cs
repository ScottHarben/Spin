namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialHome : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HoleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoleNumber = c.Byte(nullable: false),
                        HolePar = c.Byte(nullable: false),
                        HoleDistance = c.Short(nullable: false),
                        TeeModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeeModels", t => t.TeeModelId, cascadeDelete: false)
                .Index(t => t.TeeModelId);
            
            CreateTable(
                "dbo.TeeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeeName = c.String(),
                        TeePar = c.Byte(nullable: false),
                        TeeDistance = c.Short(nullable: false),
                        CourseModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseModels", t => t.CourseModelId, cascadeDelete: false)
                .Index(t => t.CourseModelId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.RoundModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoundId = c.Long(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        CourseModelId = c.Int(nullable: false),
                        TeeModelId = c.Int(nullable: false),
                        HoleModelId = c.Int(nullable: false),
                        FairwayInRegulation = c.Boolean(nullable: false),
                        GreenInRegulation = c.Boolean(nullable: false),
                        NumberOfPutts = c.Byte(nullable: false),
                        StrokesAgainstPar = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseModels", t => t.CourseModelId, cascadeDelete: false)
                .ForeignKey("dbo.HoleModels", t => t.HoleModelId, cascadeDelete: false)
                .ForeignKey("dbo.TeeModels", t => t.TeeModelId, cascadeDelete: false)
                .Index(t => t.CourseModelId)
                .Index(t => t.TeeModelId)
                .Index(t => t.HoleModelId);
            
            CreateTable(
                "dbo.StrokesAgainstParModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScoreName = c.String(),
                        StrokesAgainstPar = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RoundModels", "TeeModelId", "dbo.TeeModels");
            DropForeignKey("dbo.RoundModels", "HoleModelId", "dbo.HoleModels");
            DropForeignKey("dbo.RoundModels", "CourseModelId", "dbo.CourseModels");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.HoleModels", "TeeModelId", "dbo.TeeModels");
            DropForeignKey("dbo.TeeModels", "CourseModelId", "dbo.CourseModels");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.RoundModels", new[] { "HoleModelId" });
            DropIndex("dbo.RoundModels", new[] { "TeeModelId" });
            DropIndex("dbo.RoundModels", new[] { "CourseModelId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.TeeModels", new[] { "CourseModelId" });
            DropIndex("dbo.HoleModels", new[] { "TeeModelId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.StrokesAgainstParModels");
            DropTable("dbo.RoundModels");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TeeModels");
            DropTable("dbo.HoleModels");
            DropTable("dbo.CourseModels");
        }
    }
}

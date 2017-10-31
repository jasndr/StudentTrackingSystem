namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostGraduation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.G_PostGraduation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CurrentPosition = c.String(nullable: false),
                        CurrentStartMonthId = c.Int(nullable: false),
                        CurrentStartYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_CommonFields", t => t.CurrentStartMonthId, cascadeDelete: true)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CurrentStartMonthId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.G_PostGraduation", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_PostGraduation", "CurrentStartMonthId", "dbo.G_CommonFields");
            DropIndex("dbo.G_PostGraduation", new[] { "CurrentStartMonthId" });
            DropIndex("dbo.G_PostGraduation", new[] { "StudentID" });
            DropTable("dbo.G_PostGraduation");
        }
    }
}

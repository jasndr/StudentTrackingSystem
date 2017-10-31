namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurriculumVitae : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.G_CurriculumVitae",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        ReceivedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.G_CurriculumVitae", "StudentID", "dbo.G_Student");
            DropIndex("dbo.G_CurriculumVitae", new[] { "StudentID" });
            DropTable("dbo.G_CurriculumVitae");
        }
    }
}

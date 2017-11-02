namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Honors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.G_Honors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        HonorInformation = c.String(nullable: false),
                        HonorMonthId = c.Int(nullable: false),
                        HonorYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_CommonFields", t => t.HonorMonthId, cascadeDelete: true)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.HonorMonthId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.G_Honors", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Honors", "HonorMonthId", "dbo.G_CommonFields");
            DropIndex("dbo.G_Honors", new[] { "HonorMonthId" });
            DropIndex("dbo.G_Honors", new[] { "StudentID" });
            DropTable("dbo.G_Honors");
        }
    }
}

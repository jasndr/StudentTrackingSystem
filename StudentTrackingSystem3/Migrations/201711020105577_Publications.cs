namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Publications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.G_Publications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        PublicationInformation = c.String(nullable: false),
                        PubMonthId = c.Int(nullable: false),
                        PubYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_CommonFields", t => t.PubMonthId, cascadeDelete: true)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.PubMonthId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.G_Publications", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Publications", "PubMonthId", "dbo.G_CommonFields");
            DropIndex("dbo.G_Publications", new[] { "PubMonthId" });
            DropIndex("dbo.G_Publications", new[] { "StudentID" });
            DropTable("dbo.G_Publications");
        }
    }
}

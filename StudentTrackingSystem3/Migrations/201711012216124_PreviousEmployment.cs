namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreviousEmployment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.G_PreviousEmployment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        Position = c.String(nullable: false),
                        StartMonthId = c.Int(nullable: false),
                        StartYear = c.Int(nullable: false),
                        EndMonthId = c.Int(nullable: false),
                        EndYear = c.Int(nullable: false),
                        G_CommonFields_ID = c.Int(),
                        G_CommonFields_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_CommonFields", t => t.EndMonthId, cascadeDelete: true)
                .ForeignKey("dbo.G_CommonFields", t => t.StartMonthId)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID1)
                .Index(t => t.StudentID)
                .Index(t => t.StartMonthId)
                .Index(t => t.EndMonthId)
                .Index(t => t.G_CommonFields_ID)
                .Index(t => t.G_CommonFields_ID1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.G_PreviousEmployment", "G_CommonFields_ID1", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_PreviousEmployment", "G_CommonFields_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_PreviousEmployment", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_PreviousEmployment", "StartMonthId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_PreviousEmployment", "EndMonthId", "dbo.G_CommonFields");
            DropIndex("dbo.G_PreviousEmployment", new[] { "G_CommonFields_ID1" });
            DropIndex("dbo.G_PreviousEmployment", new[] { "G_CommonFields_ID" });
            DropIndex("dbo.G_PreviousEmployment", new[] { "EndMonthId" });
            DropIndex("dbo.G_PreviousEmployment", new[] { "StartMonthId" });
            DropIndex("dbo.G_PreviousEmployment", new[] { "StudentID" });
            DropTable("dbo.G_PreviousEmployment");
        }
    }
}

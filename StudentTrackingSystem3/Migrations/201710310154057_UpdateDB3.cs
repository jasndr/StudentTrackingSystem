namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.G_CommitteeMember",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        University = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.G_CommitteeMember", "StudentID", "dbo.G_Student");
            DropIndex("dbo.G_CommitteeMember", new[] { "StudentID" });
            DropTable("dbo.G_CommitteeMember");
        }
    }
}

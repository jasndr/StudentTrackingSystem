namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Grants : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.G_Grants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        GrantInformation = c.String(nullable: false),
                        GrantMonthId = c.Int(nullable: false),
                        GrantYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_CommonFields", t => t.GrantMonthId, cascadeDelete: true)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.GrantMonthId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.G_Grants", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Grants", "GrantMonthId", "dbo.G_CommonFields");
            DropIndex("dbo.G_Grants", new[] { "GrantMonthId" });
            DropIndex("dbo.G_Grants", new[] { "StudentID" });
            DropTable("dbo.G_Grants");
        }
    }
}

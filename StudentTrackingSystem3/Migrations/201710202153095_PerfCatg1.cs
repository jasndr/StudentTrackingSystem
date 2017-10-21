namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PerfCatg1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.G_PerformanceActivity", newName: "G_Activity");
            DropForeignKey("dbo.G_Performance", "PerformanceActivitys_ID", "dbo.G_PerformanceActivity");
            DropIndex("dbo.G_Performance", new[] { "PerformanceActivitys_ID" });
            AddColumn("dbo.G_Performance", "StudentID", c => c.Int(nullable: false));
            CreateIndex("dbo.G_Performance", "StudentID");
            AddForeignKey("dbo.G_Performance", "StudentID", "dbo.G_Student", "Id", cascadeDelete: true);
            DropColumn("dbo.G_Performance", "PerformanceActivityID");
            DropColumn("dbo.G_Performance", "PerformanceActivitys_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.G_Performance", "PerformanceActivitys_ID", c => c.Int());
            AddColumn("dbo.G_Performance", "PerformanceActivityID", c => c.Int(nullable: false));
            DropForeignKey("dbo.G_Performance", "StudentID", "dbo.G_Student");
            DropIndex("dbo.G_Performance", new[] { "StudentID" });
            DropColumn("dbo.G_Performance", "StudentID");
            CreateIndex("dbo.G_Performance", "PerformanceActivitys_ID");
            AddForeignKey("dbo.G_Performance", "PerformanceActivitys_ID", "dbo.G_PerformanceActivity", "ID");
            RenameTable(name: "dbo.G_Activity", newName: "G_PerformanceActivity");
        }
    }
}

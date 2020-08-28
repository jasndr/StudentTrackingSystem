namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreProfileFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Student", "CommonFields_ID4", "dbo.CommonFields");
            DropForeignKey("dbo.Student", "CommonFields_ID5", "dbo.CommonFields");
            DropForeignKey("dbo.Student", "CommonFields_ID6", "dbo.CommonFields");
            DropIndex("dbo.Student", new[] { "CommonFields_ID3" });
            DropIndex("dbo.Student", new[] { "CommonFields_ID4" }); /**/
            DropColumn("dbo.Student", "CommonFields_ID4");
            RenameColumn(table: "dbo.Student", name: "CommonFields_ID3", newName: "CommonFields_ID4");
            AddColumn("dbo.Student", "EmploymentStatsId", c => c.Int(nullable: false));
            AddColumn("dbo.Student", "InterimAdvisorsId", c => c.Int());
            AddColumn("dbo.Student", "PermanentAdvisorsId", c => c.Int());
            AddColumn("dbo.Student", "CommonFields_ID7", c => c.Int());
            AddColumn("dbo.Student", "CommonFields_ID8", c => c.Int());
            AddColumn("dbo.Student", "CommonFields_ID9", c => c.Int());
            CreateIndex("dbo.Student", "EmploymentStatsId");
            CreateIndex("dbo.Student", "InterimAdvisorsId");
            CreateIndex("dbo.Student", "PermanentAdvisorsId");
            CreateIndex("dbo.Student", "CommonFields_ID4");
            CreateIndex("dbo.Student", "CommonFields_ID7");
            CreateIndex("dbo.Student", "CommonFields_ID8");
            CreateIndex("dbo.Student", "CommonFields_ID9");
            AddForeignKey("dbo.Student", "CommonFields_ID4", "dbo.CommonFields", "ID");
            AddForeignKey("dbo.Student", "CommonFields_ID5", "dbo.CommonFields", "ID");
            AddForeignKey("dbo.Student", "CommonFields_ID6", "dbo.CommonFields", "ID");
            //AddForeignKey("dbo.Student", "EmploymentStatsId", "dbo.CommonFields", "ID"/*, cascadeDelete: true*/);
            AddForeignKey("dbo.Student", "InterimAdvisorsId", "dbo.CommonFields", "ID");
            AddForeignKey("dbo.Student", "PermanentAdvisorsId", "dbo.CommonFields", "ID");
            AddForeignKey("dbo.Student", "CommonFields_ID7", "dbo.CommonFields", "ID");
            AddForeignKey("dbo.Student", "CommonFields_ID8", "dbo.CommonFields", "ID");
            AddForeignKey("dbo.Student", "CommonFields_ID9", "dbo.CommonFields", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "CommonFields_ID9", "dbo.CommonFields");
            DropForeignKey("dbo.Student", "CommonFields_ID8", "dbo.CommonFields");
            DropForeignKey("dbo.Student", "CommonFields_ID7", "dbo.CommonFields");
            DropForeignKey("dbo.Student", "PermanentAdvisorsId", "dbo.CommonFields");
            DropForeignKey("dbo.Student", "InterimAdvisorsId", "dbo.CommonFields");
            DropForeignKey("dbo.Student", "EmploymentStatsId", "dbo.CommonFields");
            DropForeignKey("dbo.Student", "CommonFields_ID6", "dbo.CommonFields");
            DropForeignKey("dbo.Student", "CommonFields_ID5", "dbo.CommonFields");
            DropForeignKey("dbo.Student", "CommonFields_ID3", "dbo.CommonFields");
            DropIndex("dbo.Student", new[] { "CommonFields_ID9" });
            DropIndex("dbo.Student", new[] { "CommonFields_ID8" });
            DropIndex("dbo.Student", new[] { "CommonFields_ID7" });
            DropIndex("dbo.Student", new[] { "CommonFields_ID3" });
            DropIndex("dbo.Student", new[] { "PermanentAdvisorsId" });
            DropIndex("dbo.Student", new[] { "InterimAdvisorsId" });
            DropIndex("dbo.Student", new[] { "EmploymentStatsId" });
            DropColumn("dbo.Student", "CommonFields_ID9");
            DropColumn("dbo.Student", "CommonFields_ID8");
            DropColumn("dbo.Student", "CommonFields_ID7");
            DropColumn("dbo.Student", "PermanentAdvisorsId");
            DropColumn("dbo.Student", "InterimAdvisorsId");
            DropColumn("dbo.Student", "EmploymentStatsId");
            RenameColumn(table: "dbo.Student", name: "CommonFields_ID4", newName: "CommonFields_ID3");
            AddColumn("dbo.Student", "CommonFields_ID4", c => c.Int());
            CreateIndex("dbo.Student", "CommonFields_ID3");
            AddForeignKey("dbo.Student", "CommonFields_ID6", "dbo.CommonFields", "ID");
            AddForeignKey("dbo.Student", "CommonFields_ID5", "dbo.CommonFields", "ID");
            AddForeignKey("dbo.Student", "CommonFields_ID4", "dbo.CommonFields", "ID");
        }
    }
}

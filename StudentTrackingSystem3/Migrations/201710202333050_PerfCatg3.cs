namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PerfCatg3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.G_Performance", "Categorys_ID", "dbo.G_CommonFields");
            DropIndex("dbo.G_Performance", new[] { "Categorys_ID" });
            DropColumn("dbo.G_Performance", "CategoryID");
            RenameColumn(table: "dbo.G_Performance", name: "Categorys_ID", newName: "CategoryID");
            AlterColumn("dbo.G_Performance", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.G_Performance", "CategoryID");
            AddForeignKey("dbo.G_Performance", "CategoryID", "dbo.G_CommonFields", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.G_Performance", "CategoryID", "dbo.G_CommonFields");
            DropIndex("dbo.G_Performance", new[] { "CategoryID" });
            AlterColumn("dbo.G_Performance", "CategoryID", c => c.Int());
            RenameColumn(table: "dbo.G_Performance", name: "CategoryID", newName: "Categorys_ID");
            AddColumn("dbo.G_Performance", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.G_Performance", "Categorys_ID");
            AddForeignKey("dbo.G_Performance", "Categorys_ID", "dbo.G_CommonFields", "ID");
        }
    }
}

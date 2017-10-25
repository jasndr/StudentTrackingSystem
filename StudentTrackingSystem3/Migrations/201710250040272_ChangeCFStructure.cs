namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCFStructure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.G_Performance", "G_CommonFields_ID", c => c.Int());
            AddColumn("dbo.G_Performance", "G_CommonFields_ID1", c => c.Int());
            AddColumn("dbo.G_Performance", "G_CommonFields_ID2", c => c.Int());
            AddColumn("dbo.G_Performance", "G_CommonFields_ID3", c => c.Int());
            CreateIndex("dbo.G_Performance", "G_CommonFields_ID");
            CreateIndex("dbo.G_Performance", "G_CommonFields_ID1");
            CreateIndex("dbo.G_Performance", "G_CommonFields_ID2");
            CreateIndex("dbo.G_Performance", "G_CommonFields_ID3");
            AddForeignKey("dbo.G_Performance", "G_CommonFields_ID", "dbo.G_CommonFields", "ID");
            AddForeignKey("dbo.G_Performance", "G_CommonFields_ID1", "dbo.G_CommonFields", "ID");
            AddForeignKey("dbo.G_Performance", "G_CommonFields_ID2", "dbo.G_CommonFields", "ID");
            AddForeignKey("dbo.G_Performance", "G_CommonFields_ID3", "dbo.G_CommonFields", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.G_Performance", "G_CommonFields_ID3", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "G_CommonFields_ID2", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "G_CommonFields_ID1", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "G_CommonFields_ID", "dbo.G_CommonFields");
            DropIndex("dbo.G_Performance", new[] { "G_CommonFields_ID3" });
            DropIndex("dbo.G_Performance", new[] { "G_CommonFields_ID2" });
            DropIndex("dbo.G_Performance", new[] { "G_CommonFields_ID1" });
            DropIndex("dbo.G_Performance", new[] { "G_CommonFields_ID" });
            DropColumn("dbo.G_Performance", "G_CommonFields_ID3");
            DropColumn("dbo.G_Performance", "G_CommonFields_ID2");
            DropColumn("dbo.G_Performance", "G_CommonFields_ID1");
            DropColumn("dbo.G_Performance", "G_CommonFields_ID");
        }
    }
}

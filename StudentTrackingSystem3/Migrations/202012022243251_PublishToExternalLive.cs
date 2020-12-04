namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PublishToExternalLive : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Course", "CommonFields_ID", "dbo.CommonFields");
            //DropForeignKey("dbo.Course", "CommonFields_ID1", "dbo.CommonFields");
            //DropIndex("dbo.Course", new[] { "CommonFields_ID" });
            //DropIndex("dbo.Course", new[] { "CommonFields_ID1" });
            AddColumn("dbo.Graduation", "CommonFields_ID10", c => c.Int());
            //AddColumn("dbo.Coursework", "CommonFields_ID", c => c.Int());
            //AddColumn("dbo.Coursework", "CommonFields_ID1", c => c.Int());
            CreateIndex("dbo.Graduation", "CommonFields_ID10");
            //CreateIndex("dbo.Coursework", "CommonFields_ID");
            //CreateIndex("dbo.Coursework", "CommonFields_ID1");
            //AddForeignKey("dbo.Coursework", "CommonFields_ID", "dbo.CommonFields", "ID");
            //AddForeignKey("dbo.Coursework", "CommonFields_ID1", "dbo.CommonFields", "ID");
            AddForeignKey("dbo.Graduation", "CommonFields_ID10", "dbo.CommonFields", "ID");
            //DropColumn("dbo.Course", "CommonFields_ID");
            //DropColumn("dbo.Course", "CommonFields_ID1");
        }
        
        public override void Down()
        {
        //    AddColumn("dbo.Course", "CommonFields_ID1", c => c.Int());
        //    AddColumn("dbo.Course", "CommonFields_ID", c => c.Int());
            DropForeignKey("dbo.Graduation", "CommonFields_ID10", "dbo.CommonFields");
            //DropForeignKey("dbo.Coursework", "CommonFields_ID1", "dbo.CommonFields");
            //DropForeignKey("dbo.Coursework", "CommonFields_ID", "dbo.CommonFields");
            //DropIndex("dbo.Coursework", new[] { "CommonFields_ID1" });
            //DropIndex("dbo.Coursework", new[] { "CommonFields_ID" });
            DropIndex("dbo.Graduation", new[] { "CommonFields_ID10" });
            //DropColumn("dbo.Coursework", "CommonFields_ID1");
            //DropColumn("dbo.Coursework", "CommonFields_ID");
            DropColumn("dbo.Graduation", "CommonFields_ID10");
            //CreateIndex("dbo.Course", "CommonFields_ID1");
            //CreateIndex("dbo.Course", "CommonFields_ID");
            //AddForeignKey("dbo.Course", "CommonFields_ID1", "dbo.CommonFields", "ID");
            //AddForeignKey("dbo.Course", "CommonFields_ID", "dbo.CommonFields", "ID");
        }
    }
}

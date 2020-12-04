namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PublishToExternalLive21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Course", "CoursePlanID", "dbo.CommonFields");
            DropForeignKey("dbo.Course", "CourseTrackID", "dbo.CommonFields");
            DropIndex("dbo.Course", new[] { "CourseTrackID" });
            DropIndex("dbo.Course", new[] { "CoursePlanID" });
           // DropColumn("dbo.Course", "CourseTrackID");
            //DropColumn("dbo.Course", "CoursePlanID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Course", "CoursePlanID", c => c.Int());
            AddColumn("dbo.Course", "CourseTrackID", c => c.Int());
            CreateIndex("dbo.Course", "CoursePlanID");
            CreateIndex("dbo.Course", "CourseTrackID");
            AddForeignKey("dbo.Course", "CourseTrackID", "dbo.CommonFields", "ID");
            AddForeignKey("dbo.Course", "CoursePlanID", "dbo.CommonFields", "ID");
        }
    }
}

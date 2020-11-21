namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviseCourseworkStructure1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Course", "CoursePlanID", "dbo.CommonFields");
            DropForeignKey("dbo.Course", "CourseTrackID", "dbo.CommonFields");
            DropIndex("dbo.Course", new[] { "CourseTrackID" });
            DropIndex("dbo.Course", new[] { "CoursePlanID" });
            AlterColumn("dbo.Course", "CourseTrackID", c => c.Int());
            AlterColumn("dbo.Course", "CoursePlanID", c => c.Int());
            CreateIndex("dbo.Course", "CourseTrackID");
            CreateIndex("dbo.Course", "CoursePlanID");
            AddForeignKey("dbo.Course", "CoursePlanID", "dbo.CommonFields", "ID");
            AddForeignKey("dbo.Course", "CourseTrackID", "dbo.CommonFields", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "CourseTrackID", "dbo.CommonFields");
            DropForeignKey("dbo.Course", "CoursePlanID", "dbo.CommonFields");
            DropIndex("dbo.Course", new[] { "CoursePlanID" });
            DropIndex("dbo.Course", new[] { "CourseTrackID" });
            AlterColumn("dbo.Course", "CoursePlanID", c => c.Int(nullable: false));
            AlterColumn("dbo.Course", "CourseTrackID", c => c.Int(nullable: false));
            CreateIndex("dbo.Course", "CoursePlanID");
            CreateIndex("dbo.Course", "CourseTrackID");
            AddForeignKey("dbo.Course", "CourseTrackID", "dbo.CommonFields", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Course", "CoursePlanID", "dbo.CommonFields", "ID", cascadeDelete: true);
        }
    }
}

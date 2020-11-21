namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviseCourseworkStructure : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coursework", "SemestersID", "dbo.CommonFields");
            DropForeignKey("dbo.Coursework", "CommonFields_ID", "dbo.CommonFields");
            DropForeignKey("dbo.Coursework", "CommonFields_ID1", "dbo.CommonFields");
            DropIndex("dbo.Coursework", new[] { "SemestersID" });
            DropIndex("dbo.Coursework", new[] { "CommonFields_ID" });
            DropIndex("dbo.Coursework", new[] { "CommonFields_ID1" });
            RenameColumn(table: "dbo.Coursework", name: "GradeID", newName: "PassFailID");
            RenameIndex(table: "dbo.Coursework", name: "IX_GradeID", newName: "IX_PassFailID");
            AddColumn("dbo.Course", "CourseTrackID", c => c.Int(nullable: true));
            AddColumn("dbo.Course", "CoursePlanID", c => c.Int(nullable: true));
            AddColumn("dbo.Course", "CommonFields_ID", c => c.Int());
            AddColumn("dbo.Course", "CommonFields_ID1", c => c.Int());
            CreateIndex("dbo.Course", "CourseTrackID");
            CreateIndex("dbo.Course", "CoursePlanID");
            CreateIndex("dbo.Course", "CommonFields_ID");
            CreateIndex("dbo.Course", "CommonFields_ID1");
            AddForeignKey("dbo.Course", "CoursePlanID", "dbo.CommonFields", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Course", "CourseTrackID", "dbo.CommonFields", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Course", "CommonFields_ID", "dbo.CommonFields", "ID");
            AddForeignKey("dbo.Course", "CommonFields_ID1", "dbo.CommonFields", "ID");
            DropColumn("dbo.Coursework", "SemestersID");
            DropColumn("dbo.Coursework", "Year");
            DropColumn("dbo.Coursework", "Comments");
            DropColumn("dbo.Coursework", "CommonFields_ID");
            DropColumn("dbo.Coursework", "CommonFields_ID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coursework", "CommonFields_ID1", c => c.Int());
            AddColumn("dbo.Coursework", "CommonFields_ID", c => c.Int());
            AddColumn("dbo.Coursework", "Comments", c => c.String());
            AddColumn("dbo.Coursework", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Coursework", "SemestersID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Course", "CommonFields_ID1", "dbo.CommonFields");
            DropForeignKey("dbo.Course", "CommonFields_ID", "dbo.CommonFields");
            DropForeignKey("dbo.Course", "CourseTrackID", "dbo.CommonFields");
            DropForeignKey("dbo.Course", "CoursePlanID", "dbo.CommonFields");
            DropIndex("dbo.Course", new[] { "CommonFields_ID1" });
            DropIndex("dbo.Course", new[] { "CommonFields_ID" });
            DropIndex("dbo.Course", new[] { "CoursePlanID" });
            DropIndex("dbo.Course", new[] { "CourseTrackID" });
            DropColumn("dbo.Course", "CommonFields_ID1");
            DropColumn("dbo.Course", "CommonFields_ID");
            DropColumn("dbo.Course", "CoursePlanID");
            DropColumn("dbo.Course", "CourseTrackID");
            RenameIndex(table: "dbo.Coursework", name: "IX_PassFailID", newName: "IX_GradeID");
            RenameColumn(table: "dbo.Coursework", name: "PassFailID", newName: "GradeID");
            CreateIndex("dbo.Coursework", "CommonFields_ID1");
            CreateIndex("dbo.Coursework", "CommonFields_ID");
            CreateIndex("dbo.Coursework", "SemestersID");
            AddForeignKey("dbo.Coursework", "CommonFields_ID1", "dbo.CommonFields", "ID");
            AddForeignKey("dbo.Coursework", "CommonFields_ID", "dbo.CommonFields", "ID");
            AddForeignKey("dbo.Coursework", "SemestersID", "dbo.CommonFields", "ID");
        }
    }
}

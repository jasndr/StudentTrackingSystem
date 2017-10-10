namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.G_PrevDegree", "Student_Id", "dbo.G_Student");
            DropIndex("dbo.G_PrevDegree", new[] { "DegreeTypeId" });
            DropIndex("dbo.G_PrevDegree", new[] { "Student_Id" });
            RenameColumn(table: "dbo.G_PrevDegree", name: "Student_Id", newName: "StudentID");
            AlterColumn("dbo.G_PrevDegree", "StudentID", c => c.Int(nullable: false));
            CreateIndex("dbo.G_PrevDegree", "StudentID");
            CreateIndex("dbo.G_PrevDegree", "DegreeTypeID");
            AddForeignKey("dbo.G_PrevDegree", "StudentID", "dbo.G_Student", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.G_PrevDegree", "StudentID", "dbo.G_Student");
            DropIndex("dbo.G_PrevDegree", new[] { "DegreeTypeID" });
            DropIndex("dbo.G_PrevDegree", new[] { "StudentID" });
            AlterColumn("dbo.G_PrevDegree", "StudentID", c => c.Int());
            RenameColumn(table: "dbo.G_PrevDegree", name: "StudentID", newName: "Student_Id");
            CreateIndex("dbo.G_PrevDegree", "Student_Id");
            CreateIndex("dbo.G_PrevDegree", "DegreeTypeId");
            AddForeignKey("dbo.G_PrevDegree", "Student_Id", "dbo.G_Student", "Id");
        }
    }
}

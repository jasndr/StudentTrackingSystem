namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.G_CommonFields",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        GradePoint = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.G_Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentNumber = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        SchoolEmail = c.String(),
                        OtherEmail = c.String(),
                        Phone = c.String(),
                        GendersId = c.Int(),
                        RaceOther = c.String(),
                        DegreeProgramsId = c.Int(),
                        ConcentrationsId = c.Int(),
                        TracksId = c.Int(),
                        DegreeStart = c.DateTime(nullable: false),
                        DegreeEnd = c.DateTime(nullable: false),
                        G_CommonFields_ID = c.Int(),
                        G_CommonFields_ID1 = c.Int(),
                        G_CommonFields_ID2 = c.Int(),
                        G_CommonFields_ID3 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.G_CommonFields", t => t.ConcentrationsId)
                .ForeignKey("dbo.G_CommonFields", t => t.DegreeProgramsId)
                .ForeignKey("dbo.G_CommonFields", t => t.GendersId)
                .ForeignKey("dbo.G_CommonFields", t => t.TracksId)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID1)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID2)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID3)
                .Index(t => t.GendersId)
                .Index(t => t.DegreeProgramsId)
                .Index(t => t.ConcentrationsId)
                .Index(t => t.TracksId)
                .Index(t => t.G_CommonFields_ID)
                .Index(t => t.G_CommonFields_ID1)
                .Index(t => t.G_CommonFields_ID2)
                .Index(t => t.G_CommonFields_ID3);
            
            CreateTable(
                "dbo.G_Coursework",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        SemestersID = c.Int(),
                        Year = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        GradeID = c.Int(nullable: false),
                        G_CommonFields_ID = c.Int(),
                        G_CommonFields_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.G_CommonFields", t => t.GradeID, cascadeDelete: true)
                .ForeignKey("dbo.G_CommonFields", t => t.SemestersID)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID1)
                .Index(t => t.StudentID)
                .Index(t => t.SemestersID)
                .Index(t => t.CourseID)
                .Index(t => t.GradeID)
                .Index(t => t.G_CommonFields_ID)
                .Index(t => t.G_CommonFields_ID1);
            
            CreateTable(
                "dbo.G_Course",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Credits = c.Int(nullable: false),
                        CourseNum = c.String(),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.G_PersonRaces",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        RaceID = c.Int(nullable: false),
                        IsSelectedPR = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_Races", t => t.RaceID, cascadeDelete: true)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.RaceID);
            
            CreateTable(
                "dbo.G_Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsSelected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.G_PrevDegree",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DegreeTypeId = c.Int(nullable: false),
                        Title = c.String(),
                        GPA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SchoolName = c.String(),
                        Major = c.String(),
                        SecondMajor = c.String(),
                        Minor = c.String(),
                        DateOfAward = c.DateTime(nullable: false),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.G_CommonFields", t => t.DegreeTypeId, cascadeDelete: true)
                .ForeignKey("dbo.G_Student", t => t.Student_Id)
                .Index(t => t.DegreeTypeId)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID3", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "G_CommonFields_ID1", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID2", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "G_CommonFields_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID1", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "TracksId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_PrevDegree", "Student_Id", "dbo.G_Student");
            DropForeignKey("dbo.G_PrevDegree", "DegreeTypeId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_PersonRaces", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_PersonRaces", "RaceID", "dbo.G_Races");
            DropForeignKey("dbo.G_Student", "GendersId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "DegreeProgramsId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Coursework", "SemestersID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "GradeID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "CourseID", "dbo.G_Course");
            DropForeignKey("dbo.G_Student", "ConcentrationsId", "dbo.G_CommonFields");
            DropIndex("dbo.G_PrevDegree", new[] { "Student_Id" });
            DropIndex("dbo.G_PrevDegree", new[] { "DegreeTypeId" });
            DropIndex("dbo.G_PersonRaces", new[] { "RaceID" });
            DropIndex("dbo.G_PersonRaces", new[] { "StudentID" });
            DropIndex("dbo.G_Coursework", new[] { "G_CommonFields_ID1" });
            DropIndex("dbo.G_Coursework", new[] { "G_CommonFields_ID" });
            DropIndex("dbo.G_Coursework", new[] { "GradeID" });
            DropIndex("dbo.G_Coursework", new[] { "CourseID" });
            DropIndex("dbo.G_Coursework", new[] { "SemestersID" });
            DropIndex("dbo.G_Coursework", new[] { "StudentID" });
            DropIndex("dbo.G_Student", new[] { "G_CommonFields_ID3" });
            DropIndex("dbo.G_Student", new[] { "G_CommonFields_ID2" });
            DropIndex("dbo.G_Student", new[] { "G_CommonFields_ID1" });
            DropIndex("dbo.G_Student", new[] { "G_CommonFields_ID" });
            DropIndex("dbo.G_Student", new[] { "TracksId" });
            DropIndex("dbo.G_Student", new[] { "ConcentrationsId" });
            DropIndex("dbo.G_Student", new[] { "DegreeProgramsId" });
            DropIndex("dbo.G_Student", new[] { "GendersId" });
            DropTable("dbo.G_PrevDegree");
            DropTable("dbo.G_Races");
            DropTable("dbo.G_PersonRaces");
            DropTable("dbo.G_Course");
            DropTable("dbo.G_Coursework");
            DropTable("dbo.G_Student");
            DropTable("dbo.G_CommonFields");
        }
    }
}

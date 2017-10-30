namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.G_Activity",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        ActivitySummaryDesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.G_Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentNumber = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        SchoolEmail = c.String(nullable: false),
                        OtherEmail = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        GendersId = c.Int(nullable: false),
                        RaceOther = c.String(),
                        ConcentrationsId = c.Int(nullable: false),
                        TracksId = c.Int(nullable: false),
                        PlansId = c.Int(nullable: false),
                        DegreeStartSemsId = c.Int(nullable: false),
                        DegreeStartYear = c.Int(nullable: false),
                        G_CommonFields_ID = c.Int(),
                        G_CommonFields_ID1 = c.Int(),
                        G_CommonFields_ID2 = c.Int(),
                        G_CommonFields_ID3 = c.Int(),
                        G_CommonFields_ID4 = c.Int(),
                        G_CommonFields_ID5 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID1)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID2)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID3)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID4)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID5)
                .ForeignKey("dbo.G_CommonFields", t => t.ConcentrationsId)
                .ForeignKey("dbo.G_CommonFields", t => t.DegreeStartSemsId)
                .ForeignKey("dbo.G_CommonFields", t => t.GendersId)
                .ForeignKey("dbo.G_CommonFields", t => t.PlansId)
                .ForeignKey("dbo.G_CommonFields", t => t.TracksId)
                .Index(t => t.GendersId)
                .Index(t => t.ConcentrationsId)
                .Index(t => t.TracksId)
                .Index(t => t.PlansId)
                .Index(t => t.DegreeStartSemsId)
                .Index(t => t.G_CommonFields_ID)
                .Index(t => t.G_CommonFields_ID1)
                .Index(t => t.G_CommonFields_ID2)
                .Index(t => t.G_CommonFields_ID3)
                .Index(t => t.G_CommonFields_ID4)
                .Index(t => t.G_CommonFields_ID5);
            
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
                "dbo.G_Performance",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        CategoryInfo = c.String(nullable: false),
                        PublicationStatsID = c.Int(),
                        AbstractStatsID = c.Int(),
                        ProposalStatsID = c.Int(),
                        TeachingStatsID = c.Int(),
                        G_CommonFields_ID = c.Int(),
                        G_CommonFields_ID1 = c.Int(),
                        G_CommonFields_ID2 = c.Int(),
                        G_CommonFields_ID3 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_CommonFields", t => t.AbstractStatsID)
                .ForeignKey("dbo.G_CommonFields", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.G_CommonFields", t => t.ProposalStatsID)
                .ForeignKey("dbo.G_CommonFields", t => t.PublicationStatsID)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.G_CommonFields", t => t.TeachingStatsID)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID1)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID2)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID3)
                .Index(t => t.StudentID)
                .Index(t => t.CategoryID)
                .Index(t => t.PublicationStatsID)
                .Index(t => t.AbstractStatsID)
                .Index(t => t.ProposalStatsID)
                .Index(t => t.TeachingStatsID)
                .Index(t => t.G_CommonFields_ID)
                .Index(t => t.G_CommonFields_ID1)
                .Index(t => t.G_CommonFields_ID2)
                .Index(t => t.G_CommonFields_ID3);
            
            CreateTable(
                "dbo.G_PrevDegree",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        DegreeTypesID = c.Int(nullable: false),
                        Title = c.String(),
                        CumulativeGPA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SchoolName = c.String(nullable: false),
                        Major = c.String(nullable: false),
                        SecondMajor = c.String(),
                        Minor = c.String(),
                        DateOfAward = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.G_CommonFields", t => t.DegreeTypesID, cascadeDelete: true)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.DegreeTypesID);
            
            CreateTable(
                "dbo.G_Coursework",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        SemestersID = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        GradeID = c.Int(nullable: false),
                        Comments = c.String(),
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
                "dbo.G_File",
                c => new
                    {
                        G_FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.G_FileId)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.G_Student", "TracksId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "PlansId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_PersonRaces", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_PersonRaces", "RaceID", "dbo.G_Races");
            DropForeignKey("dbo.G_Student", "GendersId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_File", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Student", "DegreeStartSemsId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "ConcentrationsId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID5", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "G_CommonFields_ID3", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "G_CommonFields_ID1", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "G_CommonFields_ID2", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "G_CommonFields_ID1", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID4", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID3", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "G_CommonFields_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Coursework", "SemestersID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "GradeID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "CourseID", "dbo.G_Course");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID2", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_PrevDegree", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_PrevDegree", "DegreeTypesID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID1", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "G_CommonFields_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "TeachingStatsID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Performance", "PublicationStatsID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "ProposalStatsID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "CategoryID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "AbstractStatsID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Activity", "StudentID", "dbo.G_Student");
            DropIndex("dbo.G_PersonRaces", new[] { "RaceID" });
            DropIndex("dbo.G_PersonRaces", new[] { "StudentID" });
            DropIndex("dbo.G_File", new[] { "StudentID" });
            DropIndex("dbo.G_Coursework", new[] { "G_CommonFields_ID1" });
            DropIndex("dbo.G_Coursework", new[] { "G_CommonFields_ID" });
            DropIndex("dbo.G_Coursework", new[] { "GradeID" });
            DropIndex("dbo.G_Coursework", new[] { "CourseID" });
            DropIndex("dbo.G_Coursework", new[] { "SemestersID" });
            DropIndex("dbo.G_Coursework", new[] { "StudentID" });
            DropIndex("dbo.G_PrevDegree", new[] { "DegreeTypesID" });
            DropIndex("dbo.G_PrevDegree", new[] { "StudentID" });
            DropIndex("dbo.G_Performance", new[] { "G_CommonFields_ID3" });
            DropIndex("dbo.G_Performance", new[] { "G_CommonFields_ID2" });
            DropIndex("dbo.G_Performance", new[] { "G_CommonFields_ID1" });
            DropIndex("dbo.G_Performance", new[] { "G_CommonFields_ID" });
            DropIndex("dbo.G_Performance", new[] { "TeachingStatsID" });
            DropIndex("dbo.G_Performance", new[] { "ProposalStatsID" });
            DropIndex("dbo.G_Performance", new[] { "AbstractStatsID" });
            DropIndex("dbo.G_Performance", new[] { "PublicationStatsID" });
            DropIndex("dbo.G_Performance", new[] { "CategoryID" });
            DropIndex("dbo.G_Performance", new[] { "StudentID" });
            DropIndex("dbo.G_Student", new[] { "G_CommonFields_ID5" });
            DropIndex("dbo.G_Student", new[] { "G_CommonFields_ID4" });
            DropIndex("dbo.G_Student", new[] { "G_CommonFields_ID3" });
            DropIndex("dbo.G_Student", new[] { "G_CommonFields_ID2" });
            DropIndex("dbo.G_Student", new[] { "G_CommonFields_ID1" });
            DropIndex("dbo.G_Student", new[] { "G_CommonFields_ID" });
            DropIndex("dbo.G_Student", new[] { "DegreeStartSemsId" });
            DropIndex("dbo.G_Student", new[] { "PlansId" });
            DropIndex("dbo.G_Student", new[] { "TracksId" });
            DropIndex("dbo.G_Student", new[] { "ConcentrationsId" });
            DropIndex("dbo.G_Student", new[] { "GendersId" });
            DropIndex("dbo.G_Activity", new[] { "StudentID" });
            DropTable("dbo.G_Races");
            DropTable("dbo.G_PersonRaces");
            DropTable("dbo.G_File");
            DropTable("dbo.G_Course");
            DropTable("dbo.G_Coursework");
            DropTable("dbo.G_PrevDegree");
            DropTable("dbo.G_Performance");
            DropTable("dbo.G_CommonFields");
            DropTable("dbo.G_Student");
            DropTable("dbo.G_Activity");
        }
    }
}
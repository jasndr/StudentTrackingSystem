namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResetDB : DbMigration
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
                .ForeignKey("dbo.G_CommonFields", t => t.ConcentrationsId)
                .ForeignKey("dbo.G_CommonFields", t => t.DegreeStartSemsId)
                .ForeignKey("dbo.G_CommonFields", t => t.GendersId)
                .ForeignKey("dbo.G_CommonFields", t => t.PlansId)
                .ForeignKey("dbo.G_CommonFields", t => t.TracksId)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID1)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID2)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID3)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID4)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID5)
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
                "dbo.G_PerformanceActivity",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        ActivitySummaryFile = c.Binary(),
                        ActivitySummaryDesc = c.String(),
                    })
                .PrimaryKey(t => t.ID)
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
                "dbo.G_Performance",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PerformanceActivityID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        CategoryInfo = c.String(),
                        PublicationStatID = c.Int(nullable: false),
                        AbstractStatID = c.Int(nullable: false),
                        ProposalStatID = c.Int(nullable: false),
                        TeachingStatID = c.Int(nullable: false),
                        AbstractStats_ID = c.Int(),
                        Categorys_ID = c.Int(),
                        PerformanceActivitys_ID = c.Int(),
                        ProposalStats_ID = c.Int(),
                        PublicationStats_ID = c.Int(),
                        TeachingStats_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_CommonFields", t => t.AbstractStats_ID)
                .ForeignKey("dbo.G_CommonFields", t => t.Categorys_ID)
                .ForeignKey("dbo.G_PerformanceActivity", t => t.PerformanceActivitys_ID)
                .ForeignKey("dbo.G_CommonFields", t => t.ProposalStats_ID)
                .ForeignKey("dbo.G_CommonFields", t => t.PublicationStats_ID)
                .ForeignKey("dbo.G_CommonFields", t => t.TeachingStats_ID)
                .Index(t => t.AbstractStats_ID)
                .Index(t => t.Categorys_ID)
                .Index(t => t.PerformanceActivitys_ID)
                .Index(t => t.ProposalStats_ID)
                .Index(t => t.PublicationStats_ID)
                .Index(t => t.TeachingStats_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.G_Performance", "TeachingStats_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "PublicationStats_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "ProposalStats_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "PerformanceActivitys_ID", "dbo.G_PerformanceActivity");
            DropForeignKey("dbo.G_Performance", "Categorys_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "AbstractStats_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID5", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "G_CommonFields_ID1", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID4", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID3", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "G_CommonFields_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID2", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID1", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "TracksId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_PrevDegree", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_PrevDegree", "DegreeTypesID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "PlansId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_PersonRaces", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_PersonRaces", "RaceID", "dbo.G_Races");
            DropForeignKey("dbo.G_PerformanceActivity", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Student", "GendersId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "DegreeStartSemsId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Coursework", "SemestersID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "GradeID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "CourseID", "dbo.G_Course");
            DropForeignKey("dbo.G_Student", "ConcentrationsId", "dbo.G_CommonFields");
            DropIndex("dbo.G_Performance", new[] { "TeachingStats_ID" });
            DropIndex("dbo.G_Performance", new[] { "PublicationStats_ID" });
            DropIndex("dbo.G_Performance", new[] { "ProposalStats_ID" });
            DropIndex("dbo.G_Performance", new[] { "PerformanceActivitys_ID" });
            DropIndex("dbo.G_Performance", new[] { "Categorys_ID" });
            DropIndex("dbo.G_Performance", new[] { "AbstractStats_ID" });
            DropIndex("dbo.G_PrevDegree", new[] { "DegreeTypesID" });
            DropIndex("dbo.G_PrevDegree", new[] { "StudentID" });
            DropIndex("dbo.G_PersonRaces", new[] { "RaceID" });
            DropIndex("dbo.G_PersonRaces", new[] { "StudentID" });
            DropIndex("dbo.G_PerformanceActivity", new[] { "StudentID" });
            DropIndex("dbo.G_Coursework", new[] { "G_CommonFields_ID1" });
            DropIndex("dbo.G_Coursework", new[] { "G_CommonFields_ID" });
            DropIndex("dbo.G_Coursework", new[] { "GradeID" });
            DropIndex("dbo.G_Coursework", new[] { "CourseID" });
            DropIndex("dbo.G_Coursework", new[] { "SemestersID" });
            DropIndex("dbo.G_Coursework", new[] { "StudentID" });
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
            DropTable("dbo.G_Performance");
            DropTable("dbo.G_PrevDegree");
            DropTable("dbo.G_Races");
            DropTable("dbo.G_PersonRaces");
            DropTable("dbo.G_PerformanceActivity");
            DropTable("dbo.G_Course");
            DropTable("dbo.G_Coursework");
            DropTable("dbo.G_Student");
            DropTable("dbo.G_CommonFields");
        }
    }
}

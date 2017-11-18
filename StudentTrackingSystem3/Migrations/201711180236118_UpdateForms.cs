namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateForms : DbMigration
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
                        DegreeProgramsId = c.Int(nullable: false),
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
                .ForeignKey("dbo.G_CommonFields", t => t.DegreeProgramsId)
                .ForeignKey("dbo.G_CommonFields", t => t.DegreeStartSemsId)
                .ForeignKey("dbo.G_CommonFields", t => t.GendersId)
                .ForeignKey("dbo.G_CommonFields", t => t.PlansId)
                .ForeignKey("dbo.G_CommonFields", t => t.TracksId)
                .Index(t => t.GendersId)
                .Index(t => t.DegreeProgramsId)
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
                "dbo.G_CommitteeMember",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        University = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
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
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID1)
                .ForeignKey("dbo.G_CommonFields", t => t.GradeID, cascadeDelete: true)
                .ForeignKey("dbo.G_CommonFields", t => t.SemestersID)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
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
                "dbo.G_Graduation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        DegreeEndSemsId = c.Int(),
                        DegreeEndYear = c.Int(),
                        QualifierResultId = c.Int(),
                        Qualifier2ResultId = c.Int(),
                        DateOfQualification = c.DateTime(),
                        DateOfQualification2 = c.DateTime(),
                        Form2Title = c.String(),
                        Form2Date = c.DateTime(),
                        Form2ResultId = c.Int(),
                        CompExamResultId = c.Int(),
                        DateOfCompExam = c.DateTime(),
                        CompExam2ResultId = c.Int(),
                        DateOfCompExam2 = c.DateTime(),
                        AdvisorName = c.String(),
                        AdvisorEmail = c.String(),
                        AdvisorDepartment = c.String(),
                        AdvisorUniversity = c.String(),
                        Form3Title = c.String(),
                        Form3Date = c.DateTime(),
                        Form3ResultId = c.Int(),
                        FinalExamResultId = c.Int(),
                        DateOfFinalExam = c.DateTime(),
                        FinalExam2ResultId = c.Int(),
                        DateOfFinalExam2 = c.DateTime(),
                        Form2Type_ID = c.Int(),
                        G_CommonFields_ID = c.Int(),
                        G_CommonFields_ID1 = c.Int(),
                        G_CommonFields_ID2 = c.Int(),
                        G_CommonFields_ID3 = c.Int(),
                        G_CommonFields_ID4 = c.Int(),
                        G_CommonFields_ID5 = c.Int(),
                        G_CommonFields_ID6 = c.Int(),
                        G_CommonFields_ID7 = c.Int(),
                        G_CommonFields_ID8 = c.Int(),
                        G_CommonFields_ID9 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_CommonFields", t => t.CompExam2ResultId)
                .ForeignKey("dbo.G_CommonFields", t => t.CompExamResultId)
                .ForeignKey("dbo.G_CommonFields", t => t.DegreeEndSemsId)
                .ForeignKey("dbo.G_CommonFields", t => t.FinalExam2ResultId)
                .ForeignKey("dbo.G_CommonFields", t => t.FinalExamResultId)
                .ForeignKey("dbo.G_CommonFields", t => t.Form2ResultId)
                .ForeignKey("dbo.G_CommonFields", t => t.Form2Type_ID)
                .ForeignKey("dbo.G_CommonFields", t => t.Form3ResultId)
                .ForeignKey("dbo.G_CommonFields", t => t.Qualifier2ResultId)
                .ForeignKey("dbo.G_CommonFields", t => t.QualifierResultId)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID1)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID2)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID3)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID4)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID5)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID6)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID7)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID8)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID9)
                .Index(t => t.StudentID)
                .Index(t => t.DegreeEndSemsId)
                .Index(t => t.QualifierResultId)
                .Index(t => t.Qualifier2ResultId)
                .Index(t => t.Form2ResultId)
                .Index(t => t.CompExamResultId)
                .Index(t => t.CompExam2ResultId)
                .Index(t => t.Form3ResultId)
                .Index(t => t.FinalExamResultId)
                .Index(t => t.FinalExam2ResultId)
                .Index(t => t.Form2Type_ID)
                .Index(t => t.G_CommonFields_ID)
                .Index(t => t.G_CommonFields_ID1)
                .Index(t => t.G_CommonFields_ID2)
                .Index(t => t.G_CommonFields_ID3)
                .Index(t => t.G_CommonFields_ID4)
                .Index(t => t.G_CommonFields_ID5)
                .Index(t => t.G_CommonFields_ID6)
                .Index(t => t.G_CommonFields_ID7)
                .Index(t => t.G_CommonFields_ID8)
                .Index(t => t.G_CommonFields_ID9);
            
            CreateTable(
                "dbo.G_PostGraduation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CurrentPosition = c.String(nullable: false),
                        CurrentStartMonthId = c.Int(nullable: false),
                        CurrentStartYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_CommonFields", t => t.CurrentStartMonthId, cascadeDelete: true)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CurrentStartMonthId);
            
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
                "dbo.G_PreviousEmployment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        Position = c.String(nullable: false),
                        StartMonthId = c.Int(nullable: false),
                        StartYear = c.Int(nullable: false),
                        EndMonthId = c.Int(nullable: false),
                        EndYear = c.Int(nullable: false),
                        G_CommonFields_ID = c.Int(),
                        G_CommonFields_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_CommonFields", t => t.EndMonthId, cascadeDelete: true)
                .ForeignKey("dbo.G_CommonFields", t => t.StartMonthId)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID1)
                .Index(t => t.StudentID)
                .Index(t => t.StartMonthId)
                .Index(t => t.EndMonthId)
                .Index(t => t.G_CommonFields_ID)
                .Index(t => t.G_CommonFields_ID1);
            
            CreateTable(
                "dbo.G_Grants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        GrantInformation = c.String(nullable: false),
                        GrantMonthId = c.Int(nullable: false),
                        GrantYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_CommonFields", t => t.GrantMonthId, cascadeDelete: true)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.GrantMonthId);
            
            CreateTable(
                "dbo.G_Honors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        HonorInformation = c.String(nullable: false),
                        HonorMonthId = c.Int(nullable: false),
                        HonorYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_CommonFields", t => t.HonorMonthId, cascadeDelete: true)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.HonorMonthId);
            
            CreateTable(
                "dbo.G_Publications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        PublicationInformation = c.String(nullable: false),
                        PubMonthId = c.Int(nullable: false),
                        PubYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_CommonFields", t => t.PubMonthId, cascadeDelete: true)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.PubMonthId);
            
            CreateTable(
                "dbo.G_CurriculumVitae",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        ReceivedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
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
            DropForeignKey("dbo.G_Student", "DegreeProgramsId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_CurriculumVitae", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Coursework", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Coursework", "SemestersID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "GradeID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID5", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "G_CommonFields_ID3", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_PreviousEmployment", "G_CommonFields_ID1", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "G_CommonFields_ID1", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "G_CommonFields_ID9", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "G_CommonFields_ID8", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "G_CommonFields_ID7", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Publications", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Publications", "PubMonthId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "G_CommonFields_ID2", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "G_CommonFields_ID1", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID4", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID3", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Honors", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Honors", "HonorMonthId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Grants", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Grants", "GrantMonthId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "G_CommonFields_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID2", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "G_CommonFields_ID6", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "G_CommonFields_ID5", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "G_CommonFields_ID4", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "G_CommonFields_ID3", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "G_CommonFields_ID2", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_PreviousEmployment", "G_CommonFields_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_PreviousEmployment", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_PreviousEmployment", "StartMonthId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_PreviousEmployment", "EndMonthId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_PrevDegree", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_PrevDegree", "DegreeTypesID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID1", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "G_CommonFields_ID1", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_PostGraduation", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_PostGraduation", "CurrentStartMonthId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Student", "G_CommonFields_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "G_CommonFields_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Graduation", "QualifierResultId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "Qualifier2ResultId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "Form3ResultId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "Form2Type_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "Form2ResultId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "FinalExamResultId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "FinalExam2ResultId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "DegreeEndSemsId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "CompExamResultId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "CompExam2ResultId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "G_CommonFields_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "TeachingStatsID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Performance", "PublicationStatsID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "ProposalStatsID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "CategoryID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Performance", "AbstractStatsID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Coursework", "CourseID", "dbo.G_Course");
            DropForeignKey("dbo.G_CommitteeMember", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Activity", "StudentID", "dbo.G_Student");
            DropIndex("dbo.G_PersonRaces", new[] { "RaceID" });
            DropIndex("dbo.G_PersonRaces", new[] { "StudentID" });
            DropIndex("dbo.G_File", new[] { "StudentID" });
            DropIndex("dbo.G_CurriculumVitae", new[] { "StudentID" });
            DropIndex("dbo.G_Publications", new[] { "PubMonthId" });
            DropIndex("dbo.G_Publications", new[] { "StudentID" });
            DropIndex("dbo.G_Honors", new[] { "HonorMonthId" });
            DropIndex("dbo.G_Honors", new[] { "StudentID" });
            DropIndex("dbo.G_Grants", new[] { "GrantMonthId" });
            DropIndex("dbo.G_Grants", new[] { "StudentID" });
            DropIndex("dbo.G_PreviousEmployment", new[] { "G_CommonFields_ID1" });
            DropIndex("dbo.G_PreviousEmployment", new[] { "G_CommonFields_ID" });
            DropIndex("dbo.G_PreviousEmployment", new[] { "EndMonthId" });
            DropIndex("dbo.G_PreviousEmployment", new[] { "StartMonthId" });
            DropIndex("dbo.G_PreviousEmployment", new[] { "StudentID" });
            DropIndex("dbo.G_PrevDegree", new[] { "DegreeTypesID" });
            DropIndex("dbo.G_PrevDegree", new[] { "StudentID" });
            DropIndex("dbo.G_PostGraduation", new[] { "CurrentStartMonthId" });
            DropIndex("dbo.G_PostGraduation", new[] { "StudentID" });
            DropIndex("dbo.G_Graduation", new[] { "G_CommonFields_ID9" });
            DropIndex("dbo.G_Graduation", new[] { "G_CommonFields_ID8" });
            DropIndex("dbo.G_Graduation", new[] { "G_CommonFields_ID7" });
            DropIndex("dbo.G_Graduation", new[] { "G_CommonFields_ID6" });
            DropIndex("dbo.G_Graduation", new[] { "G_CommonFields_ID5" });
            DropIndex("dbo.G_Graduation", new[] { "G_CommonFields_ID4" });
            DropIndex("dbo.G_Graduation", new[] { "G_CommonFields_ID3" });
            DropIndex("dbo.G_Graduation", new[] { "G_CommonFields_ID2" });
            DropIndex("dbo.G_Graduation", new[] { "G_CommonFields_ID1" });
            DropIndex("dbo.G_Graduation", new[] { "G_CommonFields_ID" });
            DropIndex("dbo.G_Graduation", new[] { "Form2Type_ID" });
            DropIndex("dbo.G_Graduation", new[] { "FinalExam2ResultId" });
            DropIndex("dbo.G_Graduation", new[] { "FinalExamResultId" });
            DropIndex("dbo.G_Graduation", new[] { "Form3ResultId" });
            DropIndex("dbo.G_Graduation", new[] { "CompExam2ResultId" });
            DropIndex("dbo.G_Graduation", new[] { "CompExamResultId" });
            DropIndex("dbo.G_Graduation", new[] { "Form2ResultId" });
            DropIndex("dbo.G_Graduation", new[] { "Qualifier2ResultId" });
            DropIndex("dbo.G_Graduation", new[] { "QualifierResultId" });
            DropIndex("dbo.G_Graduation", new[] { "DegreeEndSemsId" });
            DropIndex("dbo.G_Graduation", new[] { "StudentID" });
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
            DropIndex("dbo.G_Coursework", new[] { "G_CommonFields_ID1" });
            DropIndex("dbo.G_Coursework", new[] { "G_CommonFields_ID" });
            DropIndex("dbo.G_Coursework", new[] { "GradeID" });
            DropIndex("dbo.G_Coursework", new[] { "CourseID" });
            DropIndex("dbo.G_Coursework", new[] { "SemestersID" });
            DropIndex("dbo.G_Coursework", new[] { "StudentID" });
            DropIndex("dbo.G_CommitteeMember", new[] { "StudentID" });
            DropIndex("dbo.G_Student", new[] { "G_CommonFields_ID5" });
            DropIndex("dbo.G_Student", new[] { "G_CommonFields_ID4" });
            DropIndex("dbo.G_Student", new[] { "G_CommonFields_ID3" });
            DropIndex("dbo.G_Student", new[] { "G_CommonFields_ID2" });
            DropIndex("dbo.G_Student", new[] { "G_CommonFields_ID1" });
            DropIndex("dbo.G_Student", new[] { "G_CommonFields_ID" });
            DropIndex("dbo.G_Student", new[] { "DegreeStartSemsId" });
            DropIndex("dbo.G_Student", new[] { "PlansId" });
            DropIndex("dbo.G_Student", new[] { "TracksId" });
            DropIndex("dbo.G_Student", new[] { "DegreeProgramsId" });
            DropIndex("dbo.G_Student", new[] { "GendersId" });
            DropIndex("dbo.G_Activity", new[] { "StudentID" });
            DropTable("dbo.G_Races");
            DropTable("dbo.G_PersonRaces");
            DropTable("dbo.G_File");
            DropTable("dbo.G_CurriculumVitae");
            DropTable("dbo.G_Publications");
            DropTable("dbo.G_Honors");
            DropTable("dbo.G_Grants");
            DropTable("dbo.G_PreviousEmployment");
            DropTable("dbo.G_PrevDegree");
            DropTable("dbo.G_PostGraduation");
            DropTable("dbo.G_Graduation");
            DropTable("dbo.G_Performance");
            DropTable("dbo.G_CommonFields");
            DropTable("dbo.G_Course");
            DropTable("dbo.G_Coursework");
            DropTable("dbo.G_CommitteeMember");
            DropTable("dbo.G_Student");
            DropTable("dbo.G_Activity");
        }
    }
}

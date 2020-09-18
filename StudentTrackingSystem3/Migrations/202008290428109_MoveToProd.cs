namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveToProd : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Activity",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            StudentID = c.Int(nullable: false),
            //            ActivitySummaryDesc = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
            //    .Index(t => t.StudentID);
            
            //CreateTable(
            //    "dbo.File",
            //    c => new
            //        {
            //            FileId = c.Int(nullable: false, identity: true),
            //            FileName = c.String(maxLength: 255),
            //            ContentType = c.String(maxLength: 100),
            //            Content = c.Binary(),
            //            FileType = c.Int(nullable: false),
            //            ManuscriptId = c.Int(),
            //            ActivityId = c.Int(),
            //            CurriculumVitaeId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.FileId)
            //    .ForeignKey("dbo.Activity", t => t.ActivityId)
            //    .ForeignKey("dbo.CurriculumVitae", t => t.CurriculumVitaeId)
            //    .ForeignKey("dbo.Manuscript", t => t.ManuscriptId)
            //    .Index(t => t.ManuscriptId)
            //    .Index(t => t.ActivityId)
            //    .Index(t => t.CurriculumVitaeId);
            
            //CreateTable(
            //    "dbo.CurriculumVitae",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            StudentID = c.Int(nullable: false),
            //            ReceivedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
            //    .Index(t => t.StudentID);
            
            //CreateTable(
            //    "dbo.Student",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            StudentNumber = c.Int(nullable: false),
            //            FirstName = c.String(nullable: false),
            //            MiddleName = c.String(),
            //            LastName = c.String(nullable: false),
            //            SchoolEmail = c.String(nullable: false),
            //            OtherEmail = c.String(nullable: false),
            //            Phone = c.String(nullable: false),
            //            GendersId = c.Int(nullable: false),
            //            RaceOther = c.String(),
            //            DegreeProgramsId = c.Int(nullable: false),
            //            TracksId = c.Int(nullable: false),
            //            PlansId = c.Int(nullable: false),
            //            DegreeStartSemsId = c.Int(nullable: false),
            //            DegreeStartYear = c.Int(nullable: false),
            //            CitizenshipStatsId = c.Int(nullable: false),
            //            EmploymentStatsId = c.Int(nullable: false),
            //            InterimAdvisorsId = c.Int(),
            //            PermanentAdvisorsId = c.Int(),
            //            CommonFields_ID = c.Int(),
            //            CommonFields_ID1 = c.Int(),
            //            CommonFields_ID2 = c.Int(),
            //            CommonFields_ID3 = c.Int(),
            //            CommonFields_ID4 = c.Int(),
            //            CommonFields_ID5 = c.Int(),
            //            CommonFields_ID6 = c.Int(),
            //            CommonFields_ID7 = c.Int(),
            //            CommonFields_ID8 = c.Int(),
            //            CommonFields_ID9 = c.Int(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID1)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID2)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID3)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID4)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID5)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID6)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID7)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID8)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID9)
            //    .ForeignKey("dbo.CommonFields", t => t.CitizenshipStatsId, cascadeDelete: true)
            //    .ForeignKey("dbo.CommonFields", t => t.DegreeProgramsId)
            //    .ForeignKey("dbo.CommonFields", t => t.DegreeStartSemsId)
            //    .ForeignKey("dbo.CommonFields", t => t.EmploymentStatsId, cascadeDelete: true)
            //    .ForeignKey("dbo.CommonFields", t => t.GendersId)
            //    .ForeignKey("dbo.CommonFields", t => t.InterimAdvisorsId)
            //    .ForeignKey("dbo.CommonFields", t => t.PermanentAdvisorsId)
            //    .ForeignKey("dbo.CommonFields", t => t.PlansId)
            //    .ForeignKey("dbo.CommonFields", t => t.TracksId)
            //    .Index(t => t.GendersId)
            //    .Index(t => t.DegreeProgramsId)
            //    .Index(t => t.TracksId)
            //    .Index(t => t.PlansId)
            //    .Index(t => t.DegreeStartSemsId)
            //    .Index(t => t.CitizenshipStatsId)
            //    .Index(t => t.EmploymentStatsId)
            //    .Index(t => t.InterimAdvisorsId)
            //    .Index(t => t.PermanentAdvisorsId)
            //    .Index(t => t.CommonFields_ID)
            //    .Index(t => t.CommonFields_ID1)
            //    .Index(t => t.CommonFields_ID2)
            //    .Index(t => t.CommonFields_ID3)
            //    .Index(t => t.CommonFields_ID4)
            //    .Index(t => t.CommonFields_ID5)
            //    .Index(t => t.CommonFields_ID6)
            //    .Index(t => t.CommonFields_ID7)
            //    .Index(t => t.CommonFields_ID8)
            //    .Index(t => t.CommonFields_ID9);
            
            //CreateTable(
            //    "dbo.CommonFields",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Category = c.String(),
            //            DisplayOrder = c.Int(nullable: false),
            //            GradePoint = c.Decimal(precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "dbo.Performance",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            StudentID = c.Int(nullable: false),
            //            CategoryID = c.Int(nullable: false),
            //            CategoryInfo = c.String(nullable: false),
            //            PublicationStatsID = c.Int(),
            //            AbstractStatsID = c.Int(),
            //            ProposalStatsID = c.Int(),
            //            TeachingStatsID = c.Int(),
            //            CommonFields_ID = c.Int(),
            //            CommonFields_ID1 = c.Int(),
            //            CommonFields_ID2 = c.Int(),
            //            CommonFields_ID3 = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.CommonFields", t => t.AbstractStatsID)
            //    .ForeignKey("dbo.CommonFields", t => t.CategoryID, cascadeDelete: true)
            //    .ForeignKey("dbo.CommonFields", t => t.ProposalStatsID)
            //    .ForeignKey("dbo.CommonFields", t => t.PublicationStatsID)
            //    .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
            //    .ForeignKey("dbo.CommonFields", t => t.TeachingStatsID)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID1)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID2)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID3)
            //    .Index(t => t.StudentID)
            //    .Index(t => t.CategoryID)
            //    .Index(t => t.PublicationStatsID)
            //    .Index(t => t.AbstractStatsID)
            //    .Index(t => t.ProposalStatsID)
            //    .Index(t => t.TeachingStatsID)
            //    .Index(t => t.CommonFields_ID)
            //    .Index(t => t.CommonFields_ID1)
            //    .Index(t => t.CommonFields_ID2)
            //    .Index(t => t.CommonFields_ID3);
            
            //CreateTable(
            //    "dbo.Graduation",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            StudentID = c.Int(nullable: false),
            //            DegreeEndSemsId = c.Int(),
            //            DegreeEndYear = c.Int(),
            //            QualifierResultId = c.Int(),
            //            Qualifier2ResultId = c.Int(),
            //            DateOfQualification = c.DateTime(),
            //            DateOfQualification2 = c.DateTime(),
            //            Form2Title = c.String(),
            //            Form2Date = c.DateTime(),
            //            Form2ResultId = c.Int(),
            //            CompExamResultId = c.Int(),
            //            DateOfCompExam = c.DateTime(),
            //            CompExam2ResultId = c.Int(),
            //            DateOfCompExam2 = c.DateTime(),
            //            AdvisorName = c.String(),
            //            AdvisorEmail = c.String(),
            //            AdvisorDepartment = c.String(),
            //            AdvisorUniversity = c.String(),
            //            Form3Title = c.String(),
            //            Form3Date = c.DateTime(),
            //            Form3ResultId = c.Int(),
            //            FinalExamResultId = c.Int(),
            //            DateOfFinalExam = c.DateTime(),
            //            FinalExam2ResultId = c.Int(),
            //            DateOfFinalExam2 = c.DateTime(),
            //            Form2Type_ID = c.Int(),
            //            CommonFields_ID = c.Int(),
            //            CommonFields_ID1 = c.Int(),
            //            CommonFields_ID2 = c.Int(),
            //            CommonFields_ID3 = c.Int(),
            //            CommonFields_ID4 = c.Int(),
            //            CommonFields_ID5 = c.Int(),
            //            CommonFields_ID6 = c.Int(),
            //            CommonFields_ID7 = c.Int(),
            //            CommonFields_ID8 = c.Int(),
            //            CommonFields_ID9 = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.CommonFields", t => t.CompExam2ResultId)
            //    .ForeignKey("dbo.CommonFields", t => t.CompExamResultId)
            //    .ForeignKey("dbo.CommonFields", t => t.DegreeEndSemsId)
            //    .ForeignKey("dbo.CommonFields", t => t.FinalExam2ResultId)
            //    .ForeignKey("dbo.CommonFields", t => t.FinalExamResultId)
            //    .ForeignKey("dbo.CommonFields", t => t.Form2ResultId)
            //    .ForeignKey("dbo.CommonFields", t => t.Form2Type_ID)
            //    .ForeignKey("dbo.CommonFields", t => t.Form3ResultId)
            //    .ForeignKey("dbo.CommonFields", t => t.Qualifier2ResultId)
            //    .ForeignKey("dbo.CommonFields", t => t.QualifierResultId)
            //    .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID1)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID2)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID3)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID4)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID5)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID6)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID7)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID8)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID9)
            //    .Index(t => t.StudentID)
            //    .Index(t => t.DegreeEndSemsId)
            //    .Index(t => t.QualifierResultId)
            //    .Index(t => t.Qualifier2ResultId)
            //    .Index(t => t.Form2ResultId)
            //    .Index(t => t.CompExamResultId)
            //    .Index(t => t.CompExam2ResultId)
            //    .Index(t => t.Form3ResultId)
            //    .Index(t => t.FinalExamResultId)
            //    .Index(t => t.FinalExam2ResultId)
            //    .Index(t => t.Form2Type_ID)
            //    .Index(t => t.CommonFields_ID)
            //    .Index(t => t.CommonFields_ID1)
            //    .Index(t => t.CommonFields_ID2)
            //    .Index(t => t.CommonFields_ID3)
            //    .Index(t => t.CommonFields_ID4)
            //    .Index(t => t.CommonFields_ID5)
            //    .Index(t => t.CommonFields_ID6)
            //    .Index(t => t.CommonFields_ID7)
            //    .Index(t => t.CommonFields_ID8)
            //    .Index(t => t.CommonFields_ID9);
            
            //CreateTable(
            //    "dbo.PostGraduation",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            StudentID = c.Int(nullable: false),
            //            CurrentPosition = c.String(nullable: false),
            //            CurrentStartMonthId = c.Int(nullable: false),
            //            CurrentStartYear = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.CommonFields", t => t.CurrentStartMonthId, cascadeDelete: true)
            //    .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
            //    .Index(t => t.StudentID)
            //    .Index(t => t.CurrentStartMonthId);
            
            //CreateTable(
            //    "dbo.PrevDegree",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            StudentID = c.Int(nullable: false),
            //            DegreeTypesID = c.Int(nullable: false),
            //            Title = c.String(),
            //            CumulativeGPA = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            SchoolName = c.String(nullable: false),
            //            Major = c.String(nullable: false),
            //            SecondMajor = c.String(),
            //            Minor = c.String(),
            //            DateOfAward = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.CommonFields", t => t.DegreeTypesID, cascadeDelete: true)
            //    .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
            //    .Index(t => t.StudentID)
            //    .Index(t => t.DegreeTypesID);
            
            //CreateTable(
            //    "dbo.PreviousEmployment",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            StudentID = c.Int(nullable: false),
            //            Position = c.String(nullable: false),
            //            Employer = c.String(nullable: false),
            //            StartMonthId = c.Int(nullable: false),
            //            StartYear = c.Int(nullable: false),
            //            EndMonthId = c.Int(nullable: false),
            //            EndYear = c.Int(nullable: false),
            //            CommonFields_ID = c.Int(),
            //            CommonFields_ID1 = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.CommonFields", t => t.EndMonthId, cascadeDelete: true)
            //    .ForeignKey("dbo.CommonFields", t => t.StartMonthId)
            //    .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID1)
            //    .Index(t => t.StudentID)
            //    .Index(t => t.StartMonthId)
            //    .Index(t => t.EndMonthId)
            //    .Index(t => t.CommonFields_ID)
            //    .Index(t => t.CommonFields_ID1);
            
            //CreateTable(
            //    "dbo.Coursework",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            StudentID = c.Int(nullable: false),
            //            SemestersID = c.Int(nullable: false),
            //            Year = c.Int(nullable: false),
            //            CourseID = c.Int(nullable: false),
            //            GradeID = c.Int(nullable: false),
            //            Comments = c.String(),
            //            CommonFields_ID = c.Int(),
            //            CommonFields_ID1 = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
            //    .ForeignKey("dbo.CommonFields", t => t.GradeID, cascadeDelete: true)
            //    .ForeignKey("dbo.CommonFields", t => t.SemestersID)
            //    .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID1)
            //    .Index(t => t.StudentID)
            //    .Index(t => t.SemestersID)
            //    .Index(t => t.CourseID)
            //    .Index(t => t.GradeID)
            //    .Index(t => t.CommonFields_ID)
            //    .Index(t => t.CommonFields_ID1);
            
            //CreateTable(
            //    "dbo.Course",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false),
            //            Credits = c.Int(nullable: false),
            //            CourseNum = c.String(),
            //            CourseName = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "dbo.Grants",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            StudentID = c.Int(nullable: false),
            //            GrantInformation = c.String(nullable: false),
            //            GrantMonthId = c.Int(nullable: false),
            //            GrantYear = c.Int(nullable: false),
            //            CommonFields_ID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.CommonFields", t => t.GrantMonthId)
            //    .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID)
            //    .Index(t => t.StudentID)
            //    .Index(t => t.GrantMonthId)
            //    .Index(t => t.CommonFields_ID);
            
            //CreateTable(
            //    "dbo.Honors",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            StudentID = c.Int(nullable: false),
            //            HonorInformation = c.String(nullable: false),
            //            HonorMonthId = c.Int(nullable: false),
            //            HonorYear = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.CommonFields", t => t.HonorMonthId, cascadeDelete: true)
            //    .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
            //    .Index(t => t.StudentID)
            //    .Index(t => t.HonorMonthId);
            
            //CreateTable(
            //    "dbo.Publications",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            StudentID = c.Int(nullable: false),
            //            PublicationInformation = c.String(nullable: false),
            //            PubMonthId = c.Int(nullable: false),
            //            PubYear = c.Int(nullable: false),
            //            CommonFields_ID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.CommonFields", t => t.PubMonthId)
            //    .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
            //    .ForeignKey("dbo.CommonFields", t => t.CommonFields_ID)
            //    .Index(t => t.StudentID)
            //    .Index(t => t.PubMonthId)
            //    .Index(t => t.CommonFields_ID);
            
            //CreateTable(
            //    "dbo.CommitteeMember",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            StudentID = c.Int(nullable: false),
            //            Name = c.String(nullable: false),
            //            Email = c.String(nullable: false),
            //            Department = c.String(nullable: false),
            //            University = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
            //    .Index(t => t.StudentID);
            
            //CreateTable(
            //    "dbo.Manuscript",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            StudentID = c.Int(nullable: false),
            //            ReceivedDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
            //    .Index(t => t.StudentID);
            
            //CreateTable(
            //    "dbo.PersonRaces",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            StudentID = c.Int(nullable: false),
            //            RaceID = c.Int(nullable: false),
            //            IsSelectedPR = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Races", t => t.RaceID, cascadeDelete: true)
            //    .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
            //    .Index(t => t.StudentID)
            //    .Index(t => t.RaceID);
            
            //CreateTable(
            //    "dbo.Races",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            IsSelected = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Student", "TracksId", "dbo.CommonFields");
            //DropForeignKey("dbo.Student", "PlansId", "dbo.CommonFields");
            //DropForeignKey("dbo.PersonRaces", "StudentID", "dbo.Student");
            //DropForeignKey("dbo.PersonRaces", "RaceID", "dbo.Races");
            //DropForeignKey("dbo.Student", "PermanentAdvisorsId", "dbo.CommonFields");
            //DropForeignKey("dbo.Manuscript", "StudentID", "dbo.Student");
            //DropForeignKey("dbo.File", "ManuscriptId", "dbo.Manuscript");
            //DropForeignKey("dbo.Student", "InterimAdvisorsId", "dbo.CommonFields");
            //DropForeignKey("dbo.Student", "GendersId", "dbo.CommonFields");
            //DropForeignKey("dbo.Student", "EmploymentStatsId", "dbo.CommonFields");
            //DropForeignKey("dbo.Student", "DegreeStartSemsId", "dbo.CommonFields");
            //DropForeignKey("dbo.Student", "DegreeProgramsId", "dbo.CommonFields");
            //DropForeignKey("dbo.CurriculumVitae", "StudentID", "dbo.Student");
            //DropForeignKey("dbo.CommitteeMember", "StudentID", "dbo.Student");
            //DropForeignKey("dbo.Student", "CitizenshipStatsId", "dbo.CommonFields");
            //DropForeignKey("dbo.Student", "CommonFields_ID9", "dbo.CommonFields");
            //DropForeignKey("dbo.Performance", "CommonFields_ID3", "dbo.CommonFields");
            //DropForeignKey("dbo.PreviousEmployment", "CommonFields_ID1", "dbo.CommonFields");
            //DropForeignKey("dbo.Coursework", "CommonFields_ID1", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "CommonFields_ID9", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "CommonFields_ID8", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "CommonFields_ID7", "dbo.CommonFields");
            //DropForeignKey("dbo.Publications", "CommonFields_ID", "dbo.CommonFields");
            //DropForeignKey("dbo.Publications", "StudentID", "dbo.Student");
            //DropForeignKey("dbo.Publications", "PubMonthId", "dbo.CommonFields");
            //DropForeignKey("dbo.Performance", "CommonFields_ID2", "dbo.CommonFields");
            //DropForeignKey("dbo.Performance", "CommonFields_ID1", "dbo.CommonFields");
            //DropForeignKey("dbo.Student", "CommonFields_ID8", "dbo.CommonFields");
            //DropForeignKey("dbo.Student", "CommonFields_ID7", "dbo.CommonFields");
            //DropForeignKey("dbo.Student", "CommonFields_ID6", "dbo.CommonFields");
            //DropForeignKey("dbo.Student", "CommonFields_ID5", "dbo.CommonFields");
            //DropForeignKey("dbo.Honors", "StudentID", "dbo.Student");
            //DropForeignKey("dbo.Honors", "HonorMonthId", "dbo.CommonFields");
            //DropForeignKey("dbo.Grants", "CommonFields_ID", "dbo.CommonFields");
            //DropForeignKey("dbo.Grants", "StudentID", "dbo.Student");
            //DropForeignKey("dbo.Grants", "GrantMonthId", "dbo.CommonFields");
            //DropForeignKey("dbo.Coursework", "CommonFields_ID", "dbo.CommonFields");
            //DropForeignKey("dbo.Coursework", "StudentID", "dbo.Student");
            //DropForeignKey("dbo.Coursework", "SemestersID", "dbo.CommonFields");
            //DropForeignKey("dbo.Coursework", "GradeID", "dbo.CommonFields");
            //DropForeignKey("dbo.Coursework", "CourseID", "dbo.Course");
            //DropForeignKey("dbo.Student", "CommonFields_ID4", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "CommonFields_ID6", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "CommonFields_ID5", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "CommonFields_ID4", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "CommonFields_ID3", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "CommonFields_ID2", "dbo.CommonFields");
            //DropForeignKey("dbo.PreviousEmployment", "CommonFields_ID", "dbo.CommonFields");
            //DropForeignKey("dbo.PreviousEmployment", "StudentID", "dbo.Student");
            //DropForeignKey("dbo.PreviousEmployment", "StartMonthId", "dbo.CommonFields");
            //DropForeignKey("dbo.PreviousEmployment", "EndMonthId", "dbo.CommonFields");
            //DropForeignKey("dbo.Student", "CommonFields_ID3", "dbo.CommonFields");
            //DropForeignKey("dbo.PrevDegree", "StudentID", "dbo.Student");
            //DropForeignKey("dbo.PrevDegree", "DegreeTypesID", "dbo.CommonFields");
            //DropForeignKey("dbo.Student", "CommonFields_ID2", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "CommonFields_ID1", "dbo.CommonFields");
            //DropForeignKey("dbo.PostGraduation", "StudentID", "dbo.Student");
            //DropForeignKey("dbo.PostGraduation", "CurrentStartMonthId", "dbo.CommonFields");
            //DropForeignKey("dbo.Student", "CommonFields_ID1", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "CommonFields_ID", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "StudentID", "dbo.Student");
            //DropForeignKey("dbo.Graduation", "QualifierResultId", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "Qualifier2ResultId", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "Form3ResultId", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "Form2Type_ID", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "Form2ResultId", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "FinalExamResultId", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "FinalExam2ResultId", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "DegreeEndSemsId", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "CompExamResultId", "dbo.CommonFields");
            //DropForeignKey("dbo.Graduation", "CompExam2ResultId", "dbo.CommonFields");
            //DropForeignKey("dbo.Student", "CommonFields_ID", "dbo.CommonFields");
            //DropForeignKey("dbo.Performance", "CommonFields_ID", "dbo.CommonFields");
            //DropForeignKey("dbo.Performance", "TeachingStatsID", "dbo.CommonFields");
            //DropForeignKey("dbo.Performance", "StudentID", "dbo.Student");
            //DropForeignKey("dbo.Performance", "PublicationStatsID", "dbo.CommonFields");
            //DropForeignKey("dbo.Performance", "ProposalStatsID", "dbo.CommonFields");
            //DropForeignKey("dbo.Performance", "CategoryID", "dbo.CommonFields");
            //DropForeignKey("dbo.Performance", "AbstractStatsID", "dbo.CommonFields");
            //DropForeignKey("dbo.Activity", "StudentID", "dbo.Student");
            //DropForeignKey("dbo.File", "CurriculumVitaeId", "dbo.CurriculumVitae");
            //DropForeignKey("dbo.File", "ActivityId", "dbo.Activity");
            //DropIndex("dbo.PersonRaces", new[] { "RaceID" });
            //DropIndex("dbo.PersonRaces", new[] { "StudentID" });
            //DropIndex("dbo.Manuscript", new[] { "StudentID" });
            //DropIndex("dbo.CommitteeMember", new[] { "StudentID" });
            //DropIndex("dbo.Publications", new[] { "CommonFields_ID" });
            //DropIndex("dbo.Publications", new[] { "PubMonthId" });
            //DropIndex("dbo.Publications", new[] { "StudentID" });
            //DropIndex("dbo.Honors", new[] { "HonorMonthId" });
            //DropIndex("dbo.Honors", new[] { "StudentID" });
            //DropIndex("dbo.Grants", new[] { "CommonFields_ID" });
            //DropIndex("dbo.Grants", new[] { "GrantMonthId" });
            //DropIndex("dbo.Grants", new[] { "StudentID" });
            //DropIndex("dbo.Coursework", new[] { "CommonFields_ID1" });
            //DropIndex("dbo.Coursework", new[] { "CommonFields_ID" });
            //DropIndex("dbo.Coursework", new[] { "GradeID" });
            //DropIndex("dbo.Coursework", new[] { "CourseID" });
            //DropIndex("dbo.Coursework", new[] { "SemestersID" });
            //DropIndex("dbo.Coursework", new[] { "StudentID" });
            //DropIndex("dbo.PreviousEmployment", new[] { "CommonFields_ID1" });
            //DropIndex("dbo.PreviousEmployment", new[] { "CommonFields_ID" });
            //DropIndex("dbo.PreviousEmployment", new[] { "EndMonthId" });
            //DropIndex("dbo.PreviousEmployment", new[] { "StartMonthId" });
            //DropIndex("dbo.PreviousEmployment", new[] { "StudentID" });
            //DropIndex("dbo.PrevDegree", new[] { "DegreeTypesID" });
            //DropIndex("dbo.PrevDegree", new[] { "StudentID" });
            //DropIndex("dbo.PostGraduation", new[] { "CurrentStartMonthId" });
            //DropIndex("dbo.PostGraduation", new[] { "StudentID" });
            //DropIndex("dbo.Graduation", new[] { "CommonFields_ID9" });
            //DropIndex("dbo.Graduation", new[] { "CommonFields_ID8" });
            //DropIndex("dbo.Graduation", new[] { "CommonFields_ID7" });
            //DropIndex("dbo.Graduation", new[] { "CommonFields_ID6" });
            //DropIndex("dbo.Graduation", new[] { "CommonFields_ID5" });
            //DropIndex("dbo.Graduation", new[] { "CommonFields_ID4" });
            //DropIndex("dbo.Graduation", new[] { "CommonFields_ID3" });
            //DropIndex("dbo.Graduation", new[] { "CommonFields_ID2" });
            //DropIndex("dbo.Graduation", new[] { "CommonFields_ID1" });
            //DropIndex("dbo.Graduation", new[] { "CommonFields_ID" });
            //DropIndex("dbo.Graduation", new[] { "Form2Type_ID" });
            //DropIndex("dbo.Graduation", new[] { "FinalExam2ResultId" });
            //DropIndex("dbo.Graduation", new[] { "FinalExamResultId" });
            //DropIndex("dbo.Graduation", new[] { "Form3ResultId" });
            //DropIndex("dbo.Graduation", new[] { "CompExam2ResultId" });
            //DropIndex("dbo.Graduation", new[] { "CompExamResultId" });
            //DropIndex("dbo.Graduation", new[] { "Form2ResultId" });
            //DropIndex("dbo.Graduation", new[] { "Qualifier2ResultId" });
            //DropIndex("dbo.Graduation", new[] { "QualifierResultId" });
            //DropIndex("dbo.Graduation", new[] { "DegreeEndSemsId" });
            //DropIndex("dbo.Graduation", new[] { "StudentID" });
            //DropIndex("dbo.Performance", new[] { "CommonFields_ID3" });
            //DropIndex("dbo.Performance", new[] { "CommonFields_ID2" });
            //DropIndex("dbo.Performance", new[] { "CommonFields_ID1" });
            //DropIndex("dbo.Performance", new[] { "CommonFields_ID" });
            //DropIndex("dbo.Performance", new[] { "TeachingStatsID" });
            //DropIndex("dbo.Performance", new[] { "ProposalStatsID" });
            //DropIndex("dbo.Performance", new[] { "AbstractStatsID" });
            //DropIndex("dbo.Performance", new[] { "PublicationStatsID" });
            //DropIndex("dbo.Performance", new[] { "CategoryID" });
            //DropIndex("dbo.Performance", new[] { "StudentID" });
            //DropIndex("dbo.Student", new[] { "CommonFields_ID9" });
            //DropIndex("dbo.Student", new[] { "CommonFields_ID8" });
            //DropIndex("dbo.Student", new[] { "CommonFields_ID7" });
            //DropIndex("dbo.Student", new[] { "CommonFields_ID6" });
            //DropIndex("dbo.Student", new[] { "CommonFields_ID5" });
            //DropIndex("dbo.Student", new[] { "CommonFields_ID4" });
            //DropIndex("dbo.Student", new[] { "CommonFields_ID3" });
            //DropIndex("dbo.Student", new[] { "CommonFields_ID2" });
            //DropIndex("dbo.Student", new[] { "CommonFields_ID1" });
            //DropIndex("dbo.Student", new[] { "CommonFields_ID" });
            //DropIndex("dbo.Student", new[] { "PermanentAdvisorsId" });
            //DropIndex("dbo.Student", new[] { "InterimAdvisorsId" });
            //DropIndex("dbo.Student", new[] { "EmploymentStatsId" });
            //DropIndex("dbo.Student", new[] { "CitizenshipStatsId" });
            //DropIndex("dbo.Student", new[] { "DegreeStartSemsId" });
            //DropIndex("dbo.Student", new[] { "PlansId" });
            //DropIndex("dbo.Student", new[] { "TracksId" });
            //DropIndex("dbo.Student", new[] { "DegreeProgramsId" });
            //DropIndex("dbo.Student", new[] { "GendersId" });
            //DropIndex("dbo.CurriculumVitae", new[] { "StudentID" });
            //DropIndex("dbo.File", new[] { "CurriculumVitaeId" });
            //DropIndex("dbo.File", new[] { "ActivityId" });
            //DropIndex("dbo.File", new[] { "ManuscriptId" });
            //DropIndex("dbo.Activity", new[] { "StudentID" });
            //DropTable("dbo.Races");
            //DropTable("dbo.PersonRaces");
            //DropTable("dbo.Manuscript");
            //DropTable("dbo.CommitteeMember");
            //DropTable("dbo.Publications");
            //DropTable("dbo.Honors");
            //DropTable("dbo.Grants");
            //DropTable("dbo.Course");
            //DropTable("dbo.Coursework");
            //DropTable("dbo.PreviousEmployment");
            //DropTable("dbo.PrevDegree");
            //DropTable("dbo.PostGraduation");
            //DropTable("dbo.Graduation");
            //DropTable("dbo.Performance");
            //DropTable("dbo.CommonFields");
            //DropTable("dbo.Student");
            //DropTable("dbo.CurriculumVitae");
            //DropTable("dbo.File");
            //DropTable("dbo.Activity");
        }
    }
}

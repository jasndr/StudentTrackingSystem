namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Graduation : DbMigration
    {
        public override void Up()
        {
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
                        DateOfQualification = c.DateTime(nullable: false),
                        Form2TypeId = c.Int(),
                        Form2Title = c.String(),
                        Form2Date = c.DateTime(nullable: false),
                        Form2ResultId = c.Int(),
                        CommitteeTypeID = c.Int(),
                        AdvisorName = c.String(),
                        AdvisorEmail = c.String(),
                        AdvisorDepartment = c.String(),
                        AdvisorUniversity = c.String(),
                        Form3Title = c.String(),
                        Form3Date = c.DateTime(nullable: false),
                        Form3Result = c.Int(),
                        Qualifier2Results_ID = c.Int(),
                        QualifierResults_ID = c.Int(),
                        G_CommonFields_ID = c.Int(),
                        G_CommonFields_ID1 = c.Int(),
                        G_CommonFields_ID2 = c.Int(),
                        G_CommonFields_ID3 = c.Int(),
                        G_CommonFields_ID4 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.G_CommonFields", t => t.DegreeEndSemsId)
                .ForeignKey("dbo.G_CommonFields", t => t.Form2ResultId)
                .ForeignKey("dbo.G_CommonFields", t => t.Form2TypeId)
                .ForeignKey("dbo.G_CommonFields", t => t.Qualifier2Results_ID)
                .ForeignKey("dbo.G_CommonFields", t => t.QualifierResults_ID)
                .ForeignKey("dbo.G_Student", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID1)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID2)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID3)
                .ForeignKey("dbo.G_CommonFields", t => t.G_CommonFields_ID4)
                .Index(t => t.StudentID)
                .Index(t => t.DegreeEndSemsId)
                .Index(t => t.Form2TypeId)
                .Index(t => t.Form2ResultId)
                .Index(t => t.Qualifier2Results_ID)
                .Index(t => t.QualifierResults_ID)
                .Index(t => t.G_CommonFields_ID)
                .Index(t => t.G_CommonFields_ID1)
                .Index(t => t.G_CommonFields_ID2)
                .Index(t => t.G_CommonFields_ID3)
                .Index(t => t.G_CommonFields_ID4);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.G_Graduation", "G_CommonFields_ID4", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "G_CommonFields_ID3", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "G_CommonFields_ID2", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "G_CommonFields_ID1", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "G_CommonFields_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "StudentID", "dbo.G_Student");
            DropForeignKey("dbo.G_Graduation", "QualifierResults_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "Qualifier2Results_ID", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "Form2TypeId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "Form2ResultId", "dbo.G_CommonFields");
            DropForeignKey("dbo.G_Graduation", "DegreeEndSemsId", "dbo.G_CommonFields");
            DropIndex("dbo.G_Graduation", new[] { "G_CommonFields_ID4" });
            DropIndex("dbo.G_Graduation", new[] { "G_CommonFields_ID3" });
            DropIndex("dbo.G_Graduation", new[] { "G_CommonFields_ID2" });
            DropIndex("dbo.G_Graduation", new[] { "G_CommonFields_ID1" });
            DropIndex("dbo.G_Graduation", new[] { "G_CommonFields_ID" });
            DropIndex("dbo.G_Graduation", new[] { "QualifierResults_ID" });
            DropIndex("dbo.G_Graduation", new[] { "Qualifier2Results_ID" });
            DropIndex("dbo.G_Graduation", new[] { "Form2ResultId" });
            DropIndex("dbo.G_Graduation", new[] { "Form2TypeId" });
            DropIndex("dbo.G_Graduation", new[] { "DegreeEndSemsId" });
            DropIndex("dbo.G_Graduation", new[] { "StudentID" });
            DropTable("dbo.G_Graduation");
        }
    }
}

namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixFileConn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.G_File", "ManuscriptID", c => c.Int(nullable: false));
            AddColumn("dbo.G_File", "CurriculumVitaeID", c => c.Int(nullable: false));
            AddColumn("dbo.G_File", "ActivityID", c => c.Int(nullable: false));
            CreateIndex("dbo.G_File", "ManuscriptID");
            CreateIndex("dbo.G_File", "ActivityID");
            CreateIndex("dbo.G_File", "CurriculumVitaeID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.G_File", new[] { "CurriculumVitaeID" });
            DropIndex("dbo.G_File", new[] { "ActivityID" });
            DropIndex("dbo.G_File", new[] { "ManuscriptID" });
            AlterColumn("dbo.G_File", "CurriculumVitaeID", c => c.Int(nullable: false));
            AlterColumn("dbo.G_File", "ActivityID", c => c.Int(nullable: false));
            AlterColumn("dbo.G_File", "ManuscriptID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.G_File", name: "ManuscriptID", newName: "G_Manuscript_ID");
            RenameColumn(table: "dbo.G_File", name: "CurriculumVitaeID", newName: "G_CurriculumVitae_ID");
            RenameColumn(table: "dbo.G_File", name: "ActivityID", newName: "G_Activity_ID");
            AddColumn("dbo.G_File", "ManuscriptID", c => c.Int(nullable: false));
            AddColumn("dbo.G_File", "CurriculumVitaeID", c => c.Int(nullable: false));
            AddColumn("dbo.G_File", "ActivityID", c => c.Int(nullable: false));
            CreateIndex("dbo.G_File", "G_Activity_ID");
            CreateIndex("dbo.G_File", "G_Manuscript_ID");
            CreateIndex("dbo.G_File", "G_CurriculumVitae_ID");
            CreateIndex("dbo.G_File", "CurriculumVitaeID");
            CreateIndex("dbo.G_File", "ActivityID");
            CreateIndex("dbo.G_File", "ManuscriptID");
        }
    }
}

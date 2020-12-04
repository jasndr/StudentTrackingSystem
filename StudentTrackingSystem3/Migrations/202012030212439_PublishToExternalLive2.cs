namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PublishToExternalLive2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Graduation", "TakenQHS601Id", c => c.Int());
            AlterColumn("dbo.Student", "OtherEmail", c => c.String(nullable: true));
            CreateIndex("dbo.Graduation", "TakenQHS601Id");
            AddForeignKey("dbo.Graduation", "TakenQHS601Id", "dbo.CommonFields", "ID");
            DropColumn("dbo.Student", "EmergencyContactName");
            DropColumn("dbo.Student", "EmergencyContactEmail");
            DropColumn("dbo.Student", "EmergencyContactPhone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "EmergencyContactPhone", c => c.String());
            AddColumn("dbo.Student", "EmergencyContactEmail", c => c.String());
            AddColumn("dbo.Student", "EmergencyContactName", c => c.String());
            DropForeignKey("dbo.Graduation", "TakenQHS601Id", "dbo.CommonFields");
            DropIndex("dbo.Graduation", new[] { "TakenQHS601Id" });
            AlterColumn("dbo.Student", "OtherEmail", c => c.String());
            DropColumn("dbo.Graduation", "TakenQHS601Id");
            DropColumn("dbo.Student", "Age");
        }
    }
}

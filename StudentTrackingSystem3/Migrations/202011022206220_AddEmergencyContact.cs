namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmergencyContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "EmergencyContactName", c => c.String());
            AddColumn("dbo.Student", "EmergencyContactEmail", c => c.String());
            AddColumn("dbo.Student", "EmergencyContactPhone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "EmergencyContactPhone");
            DropColumn("dbo.Student", "EmergencyContactEmail");
            DropColumn("dbo.Student", "EmergencyContactName");
        }
    }
}

namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfileFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "RaceAsianOther", c => c.String());
            AddColumn("dbo.Student", "RacePacIsleOther", c => c.String());
            AddColumn("dbo.Student", "EmploymentStatsOther", c => c.String());
            AddColumn("dbo.Student", "PermanentAdvisorOther", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "PermanentAdvisorOther");
            DropColumn("dbo.Student", "EmploymentStatsOther");
            DropColumn("dbo.Student", "RacePacIsleOther");
            DropColumn("dbo.Student", "RaceAsianOther");
        }
    }
}

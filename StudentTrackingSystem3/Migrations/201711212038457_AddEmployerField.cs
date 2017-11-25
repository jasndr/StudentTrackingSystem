namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployerField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.G_PreviousEmployment", "Employer", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.G_PreviousEmployment", "Employer");
        }
    }
}

namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.G_Graduation", "DateOfQualification", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.G_Graduation", "DateOfQualification", c => c.DateTime(nullable: false));
        }
    }
}

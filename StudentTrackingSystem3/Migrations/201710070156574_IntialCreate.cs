namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.G_Student", "RaceOther", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.G_Student", "RaceOther", c => c.String(nullable: false));
        }
    }
}

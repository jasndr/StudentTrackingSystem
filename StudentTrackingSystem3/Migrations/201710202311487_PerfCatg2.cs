namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PerfCatg2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.G_Performance", "CategoryInfo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.G_Performance", "CategoryInfo", c => c.String());
        }
    }
}

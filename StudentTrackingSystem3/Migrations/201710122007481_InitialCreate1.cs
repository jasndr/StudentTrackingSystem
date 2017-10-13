namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.G_PrevDegree", "Title", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.G_PrevDegree", "Title", c => c.String(nullable: false));
        }
    }
}

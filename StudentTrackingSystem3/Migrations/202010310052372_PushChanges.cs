namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PushChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "OtherEmail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "OtherEmail", c => c.String(nullable: false));
        }
    }
}

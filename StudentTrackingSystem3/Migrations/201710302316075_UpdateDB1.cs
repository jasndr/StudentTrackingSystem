namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.G_Graduation", "Form2Date", c => c.DateTime());
            AlterColumn("dbo.G_Graduation", "Form3Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.G_Graduation", "Form3Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.G_Graduation", "Form2Date", c => c.DateTime(nullable: false));
        }
    }
}

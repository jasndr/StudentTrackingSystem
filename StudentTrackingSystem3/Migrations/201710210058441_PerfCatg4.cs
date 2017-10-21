namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PerfCatg4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.G_Performance", "PublicationStatID", c => c.Int());
            AlterColumn("dbo.G_Performance", "AbstractStatID", c => c.Int());
            AlterColumn("dbo.G_Performance", "ProposalStatID", c => c.Int());
            AlterColumn("dbo.G_Performance", "TeachingStatID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.G_Performance", "TeachingStatID", c => c.Int(nullable: false));
            AlterColumn("dbo.G_Performance", "ProposalStatID", c => c.Int(nullable: false));
            AlterColumn("dbo.G_Performance", "AbstractStatID", c => c.Int(nullable: false));
            AlterColumn("dbo.G_Performance", "PublicationStatID", c => c.Int(nullable: false));
        }
    }
}

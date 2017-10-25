namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePerfStructure : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.G_Performance", name: "AbstractStats_ID", newName: "AbstractStatsID");
            RenameColumn(table: "dbo.G_Performance", name: "ProposalStats_ID", newName: "ProposalStatsID");
            RenameColumn(table: "dbo.G_Performance", name: "PublicationStats_ID", newName: "PublicationStatsID");
            RenameColumn(table: "dbo.G_Performance", name: "TeachingStats_ID", newName: "TeachingStatsID");
            RenameIndex(table: "dbo.G_Performance", name: "IX_PublicationStats_ID", newName: "IX_PublicationStatsID");
            RenameIndex(table: "dbo.G_Performance", name: "IX_AbstractStats_ID", newName: "IX_AbstractStatsID");
            RenameIndex(table: "dbo.G_Performance", name: "IX_ProposalStats_ID", newName: "IX_ProposalStatsID");
            RenameIndex(table: "dbo.G_Performance", name: "IX_TeachingStats_ID", newName: "IX_TeachingStatsID");
            DropColumn("dbo.G_Performance", "PublicationStatID");
            DropColumn("dbo.G_Performance", "AbstractStatID");
            DropColumn("dbo.G_Performance", "ProposalStatID");
            DropColumn("dbo.G_Performance", "TeachingStatID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.G_Performance", "TeachingStatID", c => c.Int());
            AddColumn("dbo.G_Performance", "ProposalStatID", c => c.Int());
            AddColumn("dbo.G_Performance", "AbstractStatID", c => c.Int());
            AddColumn("dbo.G_Performance", "PublicationStatID", c => c.Int());
            RenameIndex(table: "dbo.G_Performance", name: "IX_TeachingStatsID", newName: "IX_TeachingStats_ID");
            RenameIndex(table: "dbo.G_Performance", name: "IX_ProposalStatsID", newName: "IX_ProposalStats_ID");
            RenameIndex(table: "dbo.G_Performance", name: "IX_AbstractStatsID", newName: "IX_AbstractStats_ID");
            RenameIndex(table: "dbo.G_Performance", name: "IX_PublicationStatsID", newName: "IX_PublicationStats_ID");
            RenameColumn(table: "dbo.G_Performance", name: "TeachingStatsID", newName: "TeachingStats_ID");
            RenameColumn(table: "dbo.G_Performance", name: "PublicationStatsID", newName: "PublicationStats_ID");
            RenameColumn(table: "dbo.G_Performance", name: "ProposalStatsID", newName: "ProposalStats_ID");
            RenameColumn(table: "dbo.G_Performance", name: "AbstractStatsID", newName: "AbstractStats_ID");
        }
    }
}

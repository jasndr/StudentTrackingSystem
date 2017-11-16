namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GrandTotals1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.G_Student", name: "ConcentrationsId", newName: "DegreeProgramsId");
            RenameIndex(table: "dbo.G_Student", name: "IX_ConcentrationsId", newName: "IX_DegreeProgramsId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.G_Student", name: "IX_DegreeProgramsId", newName: "IX_ConcentrationsId");
            RenameColumn(table: "dbo.G_Student", name: "DegreeProgramsId", newName: "ConcentrationsId");
        }
    }
}

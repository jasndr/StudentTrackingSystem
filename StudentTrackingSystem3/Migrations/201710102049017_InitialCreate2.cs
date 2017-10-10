namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.G_PrevDegree", name: "DegreeTypeID", newName: "DegreeTypesID");
            RenameIndex(table: "dbo.G_PrevDegree", name: "IX_DegreeTypeID", newName: "IX_DegreeTypesID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.G_PrevDegree", name: "IX_DegreeTypesID", newName: "IX_DegreeTypeID");
            RenameColumn(table: "dbo.G_PrevDegree", name: "DegreeTypesID", newName: "DegreeTypeID");
        }
    }
}

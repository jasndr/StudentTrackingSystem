namespace StudentTrackingSystem3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGrad : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.G_Graduation", "Qualifier2ResultId");
            DropColumn("dbo.G_Graduation", "QualifierResultId");
            RenameColumn(table: "dbo.G_Graduation", name: "Qualifier2Results_ID", newName: "Qualifier2ResultId");
            RenameColumn(table: "dbo.G_Graduation", name: "QualifierResults_ID", newName: "QualifierResultId");
            RenameIndex(table: "dbo.G_Graduation", name: "IX_QualifierResults_ID", newName: "IX_QualifierResultId");
            RenameIndex(table: "dbo.G_Graduation", name: "IX_Qualifier2Results_ID", newName: "IX_Qualifier2ResultId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.G_Graduation", name: "IX_Qualifier2ResultId", newName: "IX_Qualifier2Results_ID");
            RenameIndex(table: "dbo.G_Graduation", name: "IX_QualifierResultId", newName: "IX_QualifierResults_ID");
            RenameColumn(table: "dbo.G_Graduation", name: "QualifierResultId", newName: "QualifierResults_ID");
            RenameColumn(table: "dbo.G_Graduation", name: "Qualifier2ResultId", newName: "Qualifier2Results_ID");
            AddColumn("dbo.G_Graduation", "QualifierResultId", c => c.Int());
            AddColumn("dbo.G_Graduation", "Qualifier2ResultId", c => c.Int());
        }
    }
}

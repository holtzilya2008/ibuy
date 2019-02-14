namespace IBuyServer.Domain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inheritingfromEntityBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseRecords", "CreationDate", c => c.DateTime(nullable: false, defaultValue: DateTime.UtcNow));
            AddColumn("dbo.PurchaseRecords", "ModificationDate", c => c.DateTime(nullable: false, defaultValue: DateTime.UtcNow));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseRecords", "ModificationDate");
            DropColumn("dbo.PurchaseRecords", "CreationDate");
        }
    }
}

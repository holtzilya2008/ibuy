namespace IBuyServer.Domain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingpricecolumnandatableforexpenses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        PurchaseRecordId = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PurchaseRecords", t => t.PurchaseRecordId, cascadeDelete: true)
                .Index(t => t.PurchaseRecordId);
            
            AddColumn("dbo.PurchaseRecords", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "PurchaseRecordId", "dbo.PurchaseRecords");
            DropIndex("dbo.Expenses", new[] { "PurchaseRecordId" });
            DropColumn("dbo.PurchaseRecords", "Price");
            DropTable("dbo.Expenses");
        }
    }
}

namespace TimeKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedForeignKeyOnStore : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StoreModels", "InventoryId", "dbo.InventoryModels");
            DropIndex("dbo.StoreModels", new[] { "InventoryId" });
            DropColumn("dbo.StoreModels", "InventoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StoreModels", "InventoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.StoreModels", "InventoryId");
            AddForeignKey("dbo.StoreModels", "InventoryId", "dbo.InventoryModels", "Id", cascadeDelete: true);
        }
    }
}

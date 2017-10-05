namespace TimeKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyOnInventory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InventoryModels", "StoreId", c => c.Int(nullable: false));
            CreateIndex("dbo.InventoryModels", "StoreId");
            AddForeignKey("dbo.InventoryModels", "StoreId", "dbo.StoreModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryModels", "StoreId", "dbo.StoreModels");
            DropIndex("dbo.InventoryModels", new[] { "StoreId" });
            DropColumn("dbo.InventoryModels", "StoreId");
        }
    }
}

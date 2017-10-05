namespace TimeKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingStoresForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        InventoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InventoryModels", t => t.InventoryId, cascadeDelete: true)
                .Index(t => t.InventoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreModels", "InventoryId", "dbo.InventoryModels");
            DropIndex("dbo.StoreModels", new[] { "InventoryId" });
            DropTable("dbo.StoreModels");
        }
    }
}

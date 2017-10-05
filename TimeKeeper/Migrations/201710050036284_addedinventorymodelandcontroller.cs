namespace TimeKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedinventorymodelandcontroller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InventoryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        UPCNumber = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        AmountOnHand = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InventoryModels");
        }
    }
}

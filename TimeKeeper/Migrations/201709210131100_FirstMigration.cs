namespace TimeKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeFirstName = c.String(),
                        EmployeeLastName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        TimeKeeping_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TKModels", t => t.TimeKeeping_Id)
                .Index(t => t.TimeKeeping_Id);
            
            CreateTable(
                "dbo.TKModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hours = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeModels", "TimeKeeping_Id", "dbo.TKModels");
            DropIndex("dbo.EmployeeModels", new[] { "TimeKeeping_Id" });
            DropTable("dbo.TKModels");
            DropTable("dbo.EmployeeModels");
        }
    }
}

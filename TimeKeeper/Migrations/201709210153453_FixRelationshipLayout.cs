namespace TimeKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRelationshipLayout : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeModels", "TimeKeeping_Id", "dbo.TKModels");
            DropIndex("dbo.EmployeeModels", new[] { "TimeKeeping_Id" });
            AddColumn("dbo.TKModels", "Employees_Id", c => c.Int());
            CreateIndex("dbo.TKModels", "Employees_Id");
            AddForeignKey("dbo.TKModels", "Employees_Id", "dbo.EmployeeModels", "Id");
            DropColumn("dbo.EmployeeModels", "TimeKeeping_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeModels", "TimeKeeping_Id", c => c.Int());
            DropForeignKey("dbo.TKModels", "Employees_Id", "dbo.EmployeeModels");
            DropIndex("dbo.TKModels", new[] { "Employees_Id" });
            DropColumn("dbo.TKModels", "Employees_Id");
            CreateIndex("dbo.EmployeeModels", "TimeKeeping_Id");
            AddForeignKey("dbo.EmployeeModels", "TimeKeeping_Id", "dbo.TKModels", "Id");
        }
    }
}

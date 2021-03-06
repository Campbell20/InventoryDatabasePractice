namespace TimeKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeModels", "EmployeeLastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeModels", "EmployeeLastName", c => c.String());
        }
    }
}

namespace TimeKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDataAnnontations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeModels", "EmployeeFirstName", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.EmployeeModels", "EmployeeLastName", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeModels", "EmployeeLastName", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeModels", "EmployeeFirstName", c => c.String(nullable: false));
        }
    }
}

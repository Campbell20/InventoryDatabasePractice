namespace TimeKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotationsV2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeModels", "EmployeeFirstName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeModels", "EmployeeFirstName", c => c.String());
        }
    }
}

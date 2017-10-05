namespace TimeKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustingDatatypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeModels", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TKModels", "Hours", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TKModels", "Hours", c => c.DateTime());
            DropColumn("dbo.EmployeeModels", "BirthDate");
        }
    }
}

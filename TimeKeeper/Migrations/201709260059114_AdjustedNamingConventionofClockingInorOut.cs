namespace TimeKeeper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustedNamingConventionofClockingInorOut : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TKModels", "ClockedInOut", c => c.DateTime(nullable: false));
            DropColumn("dbo.TKModels", "Hours");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TKModels", "Hours", c => c.DateTime(nullable: false));
            DropColumn("dbo.TKModels", "ClockedInOut");
        }
    }
}

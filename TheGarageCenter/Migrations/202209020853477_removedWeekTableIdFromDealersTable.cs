namespace TheGarageCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedWeekTableIdFromDealersTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Dealers", "WeekTableId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dealers", "WeekTableId", c => c.Int(nullable: false));
        }
    }
}

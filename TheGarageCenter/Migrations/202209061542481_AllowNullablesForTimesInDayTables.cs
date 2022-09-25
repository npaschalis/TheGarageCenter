namespace TheGarageCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowNullablesForTimesInDayTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DayTables", "FirstAppointment", c => c.Int());
            AlterColumn("dbo.DayTables", "LastAppointment", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DayTables", "LastAppointment", c => c.Int(nullable: false));
            AlterColumn("dbo.DayTables", "FirstAppointment", c => c.Int(nullable: false));
        }
    }
}

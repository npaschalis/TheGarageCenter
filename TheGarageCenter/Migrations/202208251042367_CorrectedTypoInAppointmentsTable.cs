namespace TheGarageCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedTypoInAppointmentsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Appointments", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Appointments", "Date");
        }
    }
}

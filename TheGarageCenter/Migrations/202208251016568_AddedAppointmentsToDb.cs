namespace TheGarageCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAppointmentsToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Hour = c.Int(nullable: false),
                        LicencePlate = c.String(nullable: false),
                        IsConfirmed = c.Boolean(nullable: false),
                        IsCancelled = c.Boolean(nullable: false),
                        DealerId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Dealers", t => t.DealerId, cascadeDelete: true)
                .Index(t => t.DealerId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "DealerId", "dbo.Dealers");
            DropForeignKey("dbo.Appointments", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Appointments", new[] { "CustomerId" });
            DropIndex("dbo.Appointments", new[] { "DealerId" });
            DropTable("dbo.Appointments");
        }
    }
}

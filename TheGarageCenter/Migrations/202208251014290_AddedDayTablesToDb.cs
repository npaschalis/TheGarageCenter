namespace TheGarageCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDayTablesToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DayTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                        FirstAppointment = c.Int(nullable: false),
                        LastAppointment = c.Int(nullable: false),
                        DealerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dealers", t => t.DealerId, cascadeDelete: true)
                .Index(t => t.DealerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DayTables", "DealerId", "dbo.Dealers");
            DropIndex("dbo.DayTables", new[] { "DealerId" });
            DropTable("dbo.DayTables");
        }
    }
}

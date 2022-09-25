namespace TheGarageCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNotAvaiableToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotAvailables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Hour = c.Int(nullable: false),
                        DealerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dealers", t => t.DealerId, cascadeDelete: true)
                .Index(t => t.DealerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotAvailables", "DealerId", "dbo.Dealers");
            DropIndex("dbo.NotAvailables", new[] { "DealerId" });
            DropTable("dbo.NotAvailables");
        }
    }
}

namespace TheGarageCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDealersToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dealers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        BrandId = c.Int(nullable: false),
                        WeekTableId = c.Int(nullable: false),
                        Brand_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.Brand_Id)
                .Index(t => t.Brand_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dealers", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Dealers", new[] { "Brand_Id" });
            DropTable("dbo.Dealers");
        }
    }
}

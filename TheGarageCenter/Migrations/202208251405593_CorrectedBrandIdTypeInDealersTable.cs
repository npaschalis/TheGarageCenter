namespace TheGarageCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedBrandIdTypeInDealersTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dealers", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Dealers", new[] { "Brand_Id" });
            DropColumn("dbo.Dealers", "BrandId");
            RenameColumn(table: "dbo.Dealers", name: "Brand_Id", newName: "BrandId");
            AlterColumn("dbo.Dealers", "BrandId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Dealers", "BrandId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Dealers", "BrandId");
            AddForeignKey("dbo.Dealers", "BrandId", "dbo.Brands", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dealers", "BrandId", "dbo.Brands");
            DropIndex("dbo.Dealers", new[] { "BrandId" });
            AlterColumn("dbo.Dealers", "BrandId", c => c.Byte());
            AlterColumn("dbo.Dealers", "BrandId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Dealers", name: "BrandId", newName: "Brand_Id");
            AddColumn("dbo.Dealers", "BrandId", c => c.Int(nullable: false));
            CreateIndex("dbo.Dealers", "Brand_Id");
            AddForeignKey("dbo.Dealers", "Brand_Id", "dbo.Brands", "Id");
        }
    }
}

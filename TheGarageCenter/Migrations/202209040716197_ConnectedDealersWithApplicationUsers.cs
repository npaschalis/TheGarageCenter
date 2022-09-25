namespace TheGarageCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectedDealersWithApplicationUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dealers", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Dealers", "ApplicationUserId");
            AddForeignKey("dbo.Dealers", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dealers", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Dealers", new[] { "ApplicationUserId" });
            DropColumn("dbo.Dealers", "ApplicationUserId");
        }
    }
}

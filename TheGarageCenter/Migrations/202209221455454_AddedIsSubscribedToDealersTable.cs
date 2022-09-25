namespace TheGarageCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsSubscribedToDealersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dealers", "isSubscribed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dealers", "isSubscribed");
        }
    }
}

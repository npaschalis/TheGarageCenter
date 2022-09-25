namespace TheGarageCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTypeOfNameInDealers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dealers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dealers", "Name", c => c.Int(nullable: false));
        }
    }
}

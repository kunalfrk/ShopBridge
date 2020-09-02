namespace ShopBridge.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateInventoryItem : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InventoryItems", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InventoryItems", "Name", c => c.String());
        }
    }
}

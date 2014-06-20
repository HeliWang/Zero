namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trade_Order", "OrderTime", c => c.DateTime());
            AlterColumn("dbo.Trade_Order", "PayTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trade_Order", "PayTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Trade_Order", "OrderTime", c => c.DateTime(nullable: false));
        }
    }
}

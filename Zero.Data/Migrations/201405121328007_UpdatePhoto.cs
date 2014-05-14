namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePhoto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product_Sku", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.Product_Sku", "UpdateTime", c => c.DateTime());
            AlterColumn("dbo.Product_Photo", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.Product_Photo", "UpdateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product_Photo", "UpdateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Product_Photo", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Product_Sku", "UpdateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Product_Sku", "CreateTime", c => c.DateTime(nullable: false));
        }
    }
}

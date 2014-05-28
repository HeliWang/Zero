namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductAttr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "SaleAttr", c => c.String());
            DropColumn("dbo.Product", "SkuAttr");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "SkuAttr", c => c.String());
            DropColumn("dbo.Product", "SaleAttr");
        }
    }
}

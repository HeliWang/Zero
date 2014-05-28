namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCart2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Cart", "SkuId");
            AddForeignKey("dbo.Cart", "SkuId", "dbo.Product_Sku", "SkuId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "SkuId", "dbo.Product_Sku");
            DropIndex("dbo.Cart", new[] { "SkuId" });
        }
    }
}

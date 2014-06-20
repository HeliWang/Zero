namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartPhotoId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product_Sku", "PhotoId", c => c.Int(nullable: false));
            AddColumn("dbo.Trade_Cart", "PhotoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Trade_Cart", "PhotoId");
            AddForeignKey("dbo.Trade_Cart", "PhotoId", "dbo.Product_Photo", "PhotoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trade_Cart", "PhotoId", "dbo.Product_Photo");
            DropIndex("dbo.Trade_Cart", new[] { "PhotoId" });
            DropColumn("dbo.Trade_Cart", "PhotoId");
            DropColumn("dbo.Product_Sku", "PhotoId");
        }
    }
}

namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSku : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product_Sku",
                c => new
                    {
                        SkuId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Attr = c.String(),
                        AttrId = c.String(),
                        AttrName = c.String(),
                        Photo = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        OuterId = c.String(),
                        Barcode = c.String(),
                        Status = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SkuId);
            
            CreateTable(
                "dbo.Product_Photo",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        AttrId = c.String(),
                        Attr = c.String(),
                        Status = c.Int(nullable: false),
                        Url = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoId);
            
            CreateTable(
                "dbo.Product_Desc",
                c => new
                    {
                        DescId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.DescId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Product_Desc");
            DropTable("dbo.Product_Photo");
            DropTable("dbo.Product_Sku");
        }
    }
}

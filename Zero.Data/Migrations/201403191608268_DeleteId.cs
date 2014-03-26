namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteId : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cate",
                c => new
                    {
                        CateId = c.Int(nullable: false, identity: true),
                        CateName = c.String(nullable: false, maxLength: 200),
                        Lid = c.Int(nullable: false),
                        Rid = c.Int(nullable: false),
                        Depth = c.Int(nullable: false),
                        Pid = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CateId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CateId = c.Int(nullable: false),
                        ProductType = c.Int(nullable: false),
                        ProductName = c.String(),
                        SubName = c.String(),
                        Zsc = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Keyword = c.String(),
                        Photo = c.String(),
                        Unit = c.String(),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bulk = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Attr = c.String(),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FreightPayer = c.String(),
                        Province = c.String(),
                        City = c.String(),
                        Groups = c.String(),
                        HasInvoice = c.Boolean(nullable: false),
                        HasWarranty = c.Boolean(nullable: false),
                        HasShowcase = c.Boolean(nullable: false),
                        Score = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Oid = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        DetailUrl = c.String(),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        CreateTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Product");
            DropTable("dbo.Cate");
        }
    }
}

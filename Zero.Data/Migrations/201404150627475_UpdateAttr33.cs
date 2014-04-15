namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAttr33 : DbMigration
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
                        CreateTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.CateId);
            
            CreateTable(
                "dbo.CateAttr",
                c => new
                    {
                        CAID = c.Int(nullable: false, identity: true),
                        CateId = c.Int(nullable: false),
                        AttrId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        IsMust = c.Int(nullable: false),
                        IsKey = c.Int(nullable: false),
                        IsSale = c.Int(nullable: false),
                        IsAllowAlias = c.Int(nullable: false),
                        Oid = c.Int(nullable: false),
                        AttrName = c.String(),
                        CateName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CAID)
                .ForeignKey("dbo.Attr", t => t.AttrId, cascadeDelete: true)
                .ForeignKey("dbo.Cate", t => t.CateId, cascadeDelete: true)
                .Index(t => t.AttrId)
                .Index(t => t.CateId);
            
            CreateTable(
                "dbo.Attr",
                c => new
                    {
                        AttrId = c.Int(nullable: false, identity: true),
                        AttrName = c.String(),
                        Oid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttrId);
            
            CreateTable(
                "dbo.AttrValue",
                c => new
                    {
                        ValueId = c.Int(nullable: false, identity: true),
                        AttrId = c.Int(nullable: false),
                        ValueName = c.String(),
                        Oid = c.Int(nullable: false),
                        Attr = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ValueId);
            
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
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        CateId = c.Int(nullable: false),
                        Uploader = c.String(),
                        FileName = c.String(),
                        Url = c.String(),
                        Ext = c.String(),
                        Size = c.Int(nullable: false),
                        AllowExt = c.String(),
                        AllowSize = c.Int(nullable: false),
                        AllowCount = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.FileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CateAttr", "CateId", "dbo.Cate");
            DropForeignKey("dbo.CateAttr", "AttrId", "dbo.Attr");
            DropIndex("dbo.CateAttr", new[] { "CateId" });
            DropIndex("dbo.CateAttr", new[] { "AttrId" });
            DropTable("dbo.Photo");
            DropTable("dbo.Product");
            DropTable("dbo.AttrValue");
            DropTable("dbo.Attr");
            DropTable("dbo.CateAttr");
            DropTable("dbo.Cate");
        }
    }
}

namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewAttr : DbMigration
    {
        public override void Up()
        {
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
                        Attr = c.String(),
                        CateName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CAID);
            
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
                        CateAttrExpand_CAID = c.Int(),
                    })
                .PrimaryKey(t => t.ValueId)
                .ForeignKey("dbo.CateAttr", t => t.CateAttrExpand_CAID)
                .Index(t => t.CateAttrExpand_CAID);
            
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
            DropForeignKey("dbo.AttrValue", "CateAttrExpand_CAID", "dbo.CateAttr");
            DropIndex("dbo.AttrValue", new[] { "CateAttrExpand_CAID" });
            DropTable("dbo.Photo");
            DropTable("dbo.Attr");
            DropTable("dbo.AttrValue");
            DropTable("dbo.CateAttr");
        }
    }
}

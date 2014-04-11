namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCateAttr3 : DbMigration
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
            
            AddColumn("dbo.AttrValue", "CateAttrExpand_CAID", c => c.Int());
            CreateIndex("dbo.AttrValue", "CateAttrExpand_CAID");
            AddForeignKey("dbo.AttrValue", "CateAttrExpand_CAID", "dbo.CateAttr", "CAID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AttrValue", "CateAttrExpand_CAID", "dbo.CateAttr");
            DropIndex("dbo.AttrValue", new[] { "CateAttrExpand_CAID" });
            DropColumn("dbo.AttrValue", "CateAttrExpand_CAID");
            DropTable("dbo.CateAttr");
        }
    }
}

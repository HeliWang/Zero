namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttrValue : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AttrValue");
        }
    }
}

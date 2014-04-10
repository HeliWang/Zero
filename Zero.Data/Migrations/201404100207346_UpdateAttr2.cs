namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAttr2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attr",
                c => new
                    {
                        AttrId = c.Int(nullable: false, identity: true),
                        AttrName = c.String(),
                        Oid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttrId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Attr");
        }
    }
}

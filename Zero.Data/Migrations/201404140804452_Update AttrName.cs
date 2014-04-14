namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAttrName : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CateAttr", "CateId");
            AddForeignKey("dbo.CateAttr", "CateId", "dbo.Cate", "CateId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CateAttr", "CateId", "dbo.Cate");
            DropIndex("dbo.CateAttr", new[] { "CateId" });
        }
    }
}

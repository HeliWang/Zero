namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustoms : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Product", "CateId");
            AddForeignKey("dbo.Product", "CateId", "dbo.Cate", "CateId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "CateId", "dbo.Cate");
            DropIndex("dbo.Product", new[] { "CateId" });
        }
    }
}

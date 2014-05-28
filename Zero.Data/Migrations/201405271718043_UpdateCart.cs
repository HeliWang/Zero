namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCart : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Cart", "ProductId");
            AddForeignKey("dbo.Cart", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "ProductId", "dbo.Product");
            DropIndex("dbo.Cart", new[] { "ProductId" });
        }
    }
}

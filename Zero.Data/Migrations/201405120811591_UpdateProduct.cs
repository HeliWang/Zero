namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "BaseAttr", c => c.String());
            AddColumn("dbo.Product", "SkuAttr", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "SkuAttr");
            DropColumn("dbo.Product", "BaseAttr");
        }
    }
}

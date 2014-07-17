namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNEws : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewsItem", "ContentId", "dbo.NewsDetail");
            DropIndex("dbo.NewsItem", new[] { "ContentId" });
            AddColumn("dbo.NewsItem", "DetailId", c => c.Int(nullable: false));
            CreateIndex("dbo.NewsItem", "DetailId");
            AddForeignKey("dbo.NewsItem", "DetailId", "dbo.NewsDetail", "DetailId", cascadeDelete: true);
            DropColumn("dbo.NewsItem", "ContentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewsItem", "ContentId", c => c.Int(nullable: false));
            DropForeignKey("dbo.NewsItem", "DetailId", "dbo.NewsDetail");
            DropIndex("dbo.NewsItem", new[] { "DetailId" });
            DropColumn("dbo.NewsItem", "DetailId");
            CreateIndex("dbo.NewsItem", "ContentId");
            AddForeignKey("dbo.NewsItem", "ContentId", "dbo.NewsDetail", "DetailId", cascadeDelete: true);
        }
    }
}

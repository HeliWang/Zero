namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNewsItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsItem", "CateId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewsItem", "CateId");
        }
    }
}

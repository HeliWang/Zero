namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsCate",
                c => new
                    {
                        CateId = c.Int(nullable: false, identity: true),
                        CateName = c.String(nullable: false, maxLength: 200),
                        Lid = c.Int(nullable: false),
                        Rid = c.Int(nullable: false),
                        Depth = c.Int(nullable: false),
                        Pid = c.Int(nullable: false),
                        Flag = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.CateId);
            
            CreateTable(
                "dbo.NewsItem",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Short = c.String(),
                        Summary = c.String(),
                        Author = c.String(),
                        Source = c.String(),
                        SourceUrl = c.String(),
                        Keyword = c.String(),
                        Tag = c.String(),
                        Photo = c.String(),
                        RedirectUrl = c.String(),
                        AllowComments = c.Int(nullable: false),
                        CommentCount = c.Int(nullable: false),
                        ClickCount = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                        ContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewsId)
                .ForeignKey("dbo.NewsDetail", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.NewsDetail",
                c => new
                    {
                        DetailId = c.Int(nullable: false, identity: true),
                        NewsId = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.DetailId);
            
            CreateTable(
                "dbo.NewsComment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        NewsId = c.Int(nullable: false),
                        Content = c.String(),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.CommentId);
            
            CreateTable(
                "dbo.NewsTag",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Summary = c.String(),
                        CreateTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsItem", "ContentId", "dbo.NewsDetail");
            DropIndex("dbo.NewsItem", new[] { "ContentId" });
            DropTable("dbo.NewsTag");
            DropTable("dbo.NewsComment");
            DropTable("dbo.NewsDetail");
            DropTable("dbo.NewsItem");
            DropTable("dbo.NewsCate");
        }
    }
}

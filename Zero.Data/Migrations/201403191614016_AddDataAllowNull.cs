namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAllowNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cate", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.Cate", "UpdateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cate", "UpdateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Cate", "CreateTime", c => c.DateTime(nullable: false));
        }
    }
}

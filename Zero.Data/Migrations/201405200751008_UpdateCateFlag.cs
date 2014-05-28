namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCateFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cate", "Flag", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cate", "Flag");
        }
    }
}

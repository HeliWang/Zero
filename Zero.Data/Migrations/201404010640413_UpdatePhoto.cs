namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePhoto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Photo", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.Photo", "UpdateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Photo", "UpdateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Photo", "CreateTime", c => c.DateTime(nullable: false));
        }
    }
}

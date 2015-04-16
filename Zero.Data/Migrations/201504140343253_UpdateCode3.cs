namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCode3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Code", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Code", "UpdateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Code", "UpdateTime", c => c.DateTime());
            AlterColumn("dbo.Code", "CreateTime", c => c.DateTime());
        }
    }
}

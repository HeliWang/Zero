namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCode2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Code", "CodeStatus", c => c.Int(nullable: false));
            DropColumn("dbo.Code", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Code", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Code", "CodeStatus");
        }
    }
}

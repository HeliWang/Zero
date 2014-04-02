namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePhoto1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photo", "AllowCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photo", "AllowCount");
        }
    }
}

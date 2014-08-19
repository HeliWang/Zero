namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Custom", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Custom", "Quantity");
        }
    }
}

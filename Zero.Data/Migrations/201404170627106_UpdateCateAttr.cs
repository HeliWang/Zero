namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCateAttr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CateAttr", "AttrValue", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CateAttr", "AttrValue");
        }
    }
}

namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Code", "CodeType", c => c.Int(nullable: false));
            AlterColumn("dbo.Code", "SendType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Code", "SendType", c => c.String());
            AlterColumn("dbo.Code", "CodeType", c => c.String());
        }
    }
}

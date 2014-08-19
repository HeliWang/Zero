namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Custom",
                c => new
                    {
                        CustomId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Ids = c.String(),
                        IsCache = c.Int(nullable: false),
                        Condition = c.String(),
                        Sql = c.String(),
                    })
                .PrimaryKey(t => t.CustomId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Custom");
        }
    }
}

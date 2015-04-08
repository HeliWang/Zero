namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Code",
                c => new
                    {
                        CodeId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Operater = c.String(),
                        CodeType = c.String(),
                        SendType = c.String(),
                        SendNo = c.String(),
                        Num = c.String(),
                        Content = c.String(),
                        Result = c.String(),
                        Status = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.CodeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Code");
        }
    }
}

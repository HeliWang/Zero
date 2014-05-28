namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SkuId = c.Int(nullable: false),
                        Attr = c.String(),
                        Quantity = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        GuestId = c.String(),
                        CreateTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.CartId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        GuestId = c.String(),
                        RealName = c.String(),
                        Nick = c.String(),
                        Avatar = c.String(),
                        Sex = c.String(),
                        Email = c.String(),
                        Fax = c.String(),
                        QQ = c.String(),
                        Phone = c.String(),
                        Mobile = c.String(),
                        Province = c.String(),
                        City = c.String(),
                        District = c.String(),
                        Address = c.String(),
                        Zip = c.String(),
                        Level = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Birthday = c.DateTime(),
                        RegTime = c.DateTime(),
                        UpdateTime = c.DateTime(),
                        LastVisit = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Cart");
        }
    }
}

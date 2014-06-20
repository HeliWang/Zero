namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocaton : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User_Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Zip = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        State = c.String(),
                        District = c.String(),
                        Address = c.String(),
                        Mobile = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User_Location");
        }
    }
}

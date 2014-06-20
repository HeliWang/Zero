namespace Zero.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trade_Snapshot", "FinalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Trade_Snapshot", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Trade_Snapshot", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Trade_Snapshot", "CateId", c => c.Int(nullable: false));
            AddColumn("dbo.Trade_Snapshot", "ProductType", c => c.Int(nullable: false));
            AddColumn("dbo.Trade_Snapshot", "ProductName", c => c.String());
            AddColumn("dbo.Trade_Snapshot", "BaseAttr", c => c.String());
            AddColumn("dbo.Trade_Snapshot", "SaleAttr", c => c.String());
            AddColumn("dbo.Trade_Snapshot", "SubName", c => c.String());
            AddColumn("dbo.Trade_Snapshot", "Zsc", c => c.String());
            AddColumn("dbo.Trade_Snapshot", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Trade_Snapshot", "Keyword", c => c.String());
            AddColumn("dbo.Trade_Snapshot", "Photo", c => c.String());
            AddColumn("dbo.Trade_Snapshot", "Unit", c => c.String());
            AddColumn("dbo.Trade_Snapshot", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Trade_Snapshot", "Bulk", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Trade_Snapshot", "ProductAttr", c => c.String());
            AddColumn("dbo.Trade_Snapshot", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Trade_Snapshot", "FreightPayer", c => c.String());
            AddColumn("dbo.Trade_Snapshot", "Province", c => c.String());
            AddColumn("dbo.Trade_Snapshot", "City", c => c.String());
            AddColumn("dbo.Trade_Snapshot", "Groups", c => c.String());
            AddColumn("dbo.Trade_Snapshot", "HasInvoice", c => c.Boolean(nullable: false));
            AddColumn("dbo.Trade_Snapshot", "HasWarranty", c => c.Boolean(nullable: false));
            AddColumn("dbo.Trade_Snapshot", "HasShowcase", c => c.Boolean(nullable: false));
            AddColumn("dbo.Trade_Snapshot", "Score", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Trade_Snapshot", "Oid", c => c.Int(nullable: false));
            AddColumn("dbo.Trade_Snapshot", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Trade_Snapshot", "DetailUrl", c => c.String());
            AddColumn("dbo.Trade_Snapshot", "StartTime", c => c.DateTime());
            AddColumn("dbo.Trade_Snapshot", "EndTime", c => c.DateTime());
            AddColumn("dbo.Trade_Snapshot", "CreateTime", c => c.DateTime());
            AddColumn("dbo.Trade_Snapshot", "UpdateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trade_Snapshot", "UpdateTime");
            DropColumn("dbo.Trade_Snapshot", "CreateTime");
            DropColumn("dbo.Trade_Snapshot", "EndTime");
            DropColumn("dbo.Trade_Snapshot", "StartTime");
            DropColumn("dbo.Trade_Snapshot", "DetailUrl");
            DropColumn("dbo.Trade_Snapshot", "Status");
            DropColumn("dbo.Trade_Snapshot", "Oid");
            DropColumn("dbo.Trade_Snapshot", "Score");
            DropColumn("dbo.Trade_Snapshot", "HasShowcase");
            DropColumn("dbo.Trade_Snapshot", "HasWarranty");
            DropColumn("dbo.Trade_Snapshot", "HasInvoice");
            DropColumn("dbo.Trade_Snapshot", "Groups");
            DropColumn("dbo.Trade_Snapshot", "City");
            DropColumn("dbo.Trade_Snapshot", "Province");
            DropColumn("dbo.Trade_Snapshot", "FreightPayer");
            DropColumn("dbo.Trade_Snapshot", "Discount");
            DropColumn("dbo.Trade_Snapshot", "ProductAttr");
            DropColumn("dbo.Trade_Snapshot", "Bulk");
            DropColumn("dbo.Trade_Snapshot", "Weight");
            DropColumn("dbo.Trade_Snapshot", "Unit");
            DropColumn("dbo.Trade_Snapshot", "Photo");
            DropColumn("dbo.Trade_Snapshot", "Keyword");
            DropColumn("dbo.Trade_Snapshot", "Amount");
            DropColumn("dbo.Trade_Snapshot", "Zsc");
            DropColumn("dbo.Trade_Snapshot", "SubName");
            DropColumn("dbo.Trade_Snapshot", "SaleAttr");
            DropColumn("dbo.Trade_Snapshot", "BaseAttr");
            DropColumn("dbo.Trade_Snapshot", "ProductName");
            DropColumn("dbo.Trade_Snapshot", "ProductType");
            DropColumn("dbo.Trade_Snapshot", "CateId");
            DropColumn("dbo.Trade_Snapshot", "UserId");
            DropColumn("dbo.Trade_Snapshot", "ProductId");
            DropColumn("dbo.Trade_Snapshot", "FinalPrice");
        }
    }
}

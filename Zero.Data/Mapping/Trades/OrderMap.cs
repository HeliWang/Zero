using System;
using Zero.Domain.Trades;
using Zero.Domain.Products;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.Trades
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            this.HasKey(o=>o.OrderId);

            // Table & Column Mappings
            this.ToTable("Trade_Order");

            //Ignore
            //this.Ignore(c => c.id);
        }
    }
}

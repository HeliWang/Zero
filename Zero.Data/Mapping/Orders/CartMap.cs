using System;
using Zero.Domain.Orders;
using Zero.Domain.Products;
using System.Data.Entity.ModelConfiguration;


namespace Zero.Data.Mapping.Orders
{
    public class CartMap : EntityTypeConfiguration<Cart>
    {
        public CartMap()
        {
            // Primary Key
            this.HasKey(c=>c.CartId);

            // Table & Column Mappings
            this.ToTable("Cart");

            //Ignore
            //this.Ignore(c => c.id);

            this.HasRequired(c => c.Product)
                .WithMany()
                .HasForeignKey(c => c.ProductId);

            this.HasRequired(c => c.Sku)
               .WithMany()
               .HasForeignKey(c => c.SkuId);
        }
    }
}

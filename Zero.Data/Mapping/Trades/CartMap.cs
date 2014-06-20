using System;
using Zero.Domain.Trades;
using Zero.Domain.Products;
using System.Data.Entity.ModelConfiguration;


namespace Zero.Data.Mapping.Trades
{
    public class CartMap : EntityTypeConfiguration<Cart>
    {
        public CartMap()
        {
            // Primary Key
            this.HasKey(c=>c.CartId);

            // Table & Column Mappings
            this.ToTable("Trade_Cart");

            //Ignore
            //this.Ignore(c => c.id);

            this.HasRequired(c => c.Product)
                .WithMany()
                .HasForeignKey(c => c.ProductId);

            this.HasRequired(c => c.Sku)
               .WithMany()
               .HasForeignKey(c => c.SkuId);

            this.HasRequired(c => c.ProductPhoto)
               .WithMany()
               .HasForeignKey(c => c.PhotoId);
        }
    }
}

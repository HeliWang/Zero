using System;
using Zero.Domain.Products;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.Products
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            this.ToTable("Product");
            this.HasKey(p => p.ProductId);

            //Ignore
            this.Ignore(p => p.id);
            this.Ignore(p => p.CateUrl);
            this.Ignore(p=>p.SkuList);
            this.Ignore(p => p.PhotoList);
            this.Ignore(p => p.Desc);
        }
    }
}

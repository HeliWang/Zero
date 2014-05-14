using System;
using Zero.Domain.Products;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.Products
{
    public class SkuMap : EntityTypeConfiguration<Sku>
    {
        public SkuMap()
        {
            this.ToTable("Product_Sku");
            this.HasKey(s => s.SkuId);

            //Ignore
            //this.Ignore(s => s.id);
        }
    }
}

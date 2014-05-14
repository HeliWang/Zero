using System;
using Zero.Domain.Products;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.Products
{
    public class ProductDescMap : EntityTypeConfiguration<ProductDesc>
    {
        public ProductDescMap()
        {
            this.ToTable("Product_Desc");
            this.HasKey(d => d.DescId);

            //Ignore
            //this.Ignore(s => s.id);
        }
    }
}

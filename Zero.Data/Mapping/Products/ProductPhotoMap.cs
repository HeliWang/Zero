using System;
using Zero.Domain.Products;
using System.Data.Entity.ModelConfiguration;

namespace Zero.Data.Mapping.Products
{
    public class ProductPhotoMap : EntityTypeConfiguration<ProductPhoto>
    {
        public ProductPhotoMap()
        {
            this.ToTable("Product_Photo");
            this.HasKey(s => s.PhotoId);

            //Ignore
            //this.Ignore(s => s.id);
        }
    }
}

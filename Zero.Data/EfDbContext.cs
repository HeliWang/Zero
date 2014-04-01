using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using Zero.Data.Mapping.Products;
using Zero.Data.Mapping.Cates;
using Zero.Data.Mapping.Upload;
namespace Zero.Data
{
    public class EfDbContext : DbContext
    {
        public EfDbContext()
            : base("ZeroData")
        {
        }

        //public DbSet<Cate> Cates { get; set; }

        //public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CateMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new PhotoMap());
        }
    }

    //public class CategoryDbContext : DbContext
    //{
    //    public IQueryable<CateBase> Categories { get; set; }

    //    public CategoryDbContext()
    //        : base("CategoryDataBase")
    //    {
    //    }
    //}
}

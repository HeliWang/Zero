using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero.Domain.Products;

namespace Zero.Mvc.Manage.Models
{
    public class ProductModel
    {
        public Product Product { get; set; }
        public List<Sku> SkuList { get; set; }
        public List<ProductPhoto> PhotoList { get; set; }
    }
}
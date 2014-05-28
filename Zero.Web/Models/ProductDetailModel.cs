using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero.Domain.Cates;
using Zero.Domain.Products;

namespace Zero.Web.Models
{
    public class ProductDetailModel
    {
        public ProductDetailModel()
        {
            CateList = new List<Cate>();
        }

        public List<Cate> CateList { get; set; }

        public Product Product { get; set; }

        public string SkuList { get; set; }
    }
}
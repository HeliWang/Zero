using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero.Domain.Cates;
using Zero.Domain.Products;

namespace Zero.Web.Models
{
    public class ProductListModel
    {
        public ProductListModel()
        {
            CateAttrList = new List<CateAttr>();
        }

        public ProductSearch ProductSearch { get; set; }

        public List<Product> ProductList { get; set; }

        public List<CateAttr> CateAttrList { get; set; }
    }
}
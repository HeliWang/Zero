using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero.Domain.Cates;
using Zero.Domain.Products;
using Zero.Core.Web;

namespace Zero.Web.Areas.Site.Models
{
    public class ProductListModel
    {
        public ProductListModel()
        {
            CateAttrList = new List<CateAttr>();
        }

        public ProductSearch ProductSearch { get; set; }

        public IPage<Product> ProductPage { get; set; }

        public List<Cate> PathCateList { get; set; }

        public List<Cate> ParentCateList { get; set; }

        public List<Cate> CateList { get; set; }

        public List<CateAttr> CateAttrList { get; set; }
    }
}
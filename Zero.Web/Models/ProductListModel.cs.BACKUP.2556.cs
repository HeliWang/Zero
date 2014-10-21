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

        public List<Cate> PathCateList { get; set; }

<<<<<<< HEAD
        public List<Cate> ParentCateList { get; set; }

=======
>>>>>>> 2cac215f8a49f797bf3bd9affc26de678344eaa5
        public List<List<Cate>> CateList { get; set; }

        public List<CateAttr> CateAttrList { get; set; }
    }
}
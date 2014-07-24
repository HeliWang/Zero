using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Zero.Domain.Cates;
using Zero.Domain.Products;
using Zero.Service.Cates;
using Zero.Service.Products;
using Zero.Web.Models;
using Zero.Core.Web;

namespace Zero.Web.Controllers
{
    public class ProductController : Controller
    {
        public IProductService _productService;
        public CateService _cateService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
            _cateService = new CateService();
        }

        public ActionResult Index()
        {
            ProductListModel model = new ProductListModel();

            int pageSize = 30;
            int pageIndex = 0;

            model.ProductList = _productService.GetList(pageIndex, pageSize).Items;

            return View(model);
        }

        public ActionResult Detail()
        {
            int productId = RequestHelper.QueryInt("productId");

            ProductDetailModel model = new ProductDetailModel();

            if (productId > 0)
            {
                model.Product = _productService.GetById(productId);
                model.Product.Desc = _productService.GetDescById(productId);
            }

            if (model.Product == null)
            {
                Response.Redirect("http://w.zero.com/");
            }

            if (model.Product.CateId > 0)
            {
                model.CateList = _cateService.GetPath(model.Product.CateId);
            }

            model.SkuList =JsonHelper.Serialize(_productService.GetSkuList(productId));

            return View(model);
        }
    }
}

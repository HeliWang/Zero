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
            ProductSearch search = new ProductSearch();
            search.CateId=RequestHelper.AllInt("CateId");
            int pageSize = 30;
            int pageIndex = 0;

            //类别信息
            List<Cate> allCateList = _cateService.GetList(0, 0);

            if (search.CateId > 0)
            {
                Cate cate = allCateList.SingleOrDefault(c => c.CateId == search.CateId);

                if (cate != null)
                {
                    search.Lid = cate.Lid;
                    search.Rid = cate.Rid;

                    //获取分类路径
                    model.PathCateList = allCateList.Where(ac => ac.Lid < cate.Lid && ac.Rid > cate.Rid).ToList();

                    //获取分类信息
                    if (cate.Depth == 1)
                    {
                        model.CateList = allCateList.Where(ac => ac.Lid > cate.Lid && ac.Rid < cate.Rid && ac.Depth == 2).ToList();
                    }
                    else if (cate.Depth == 2)
                    {
                        model.CateList = allCateList.Where(ac => ac.Pid == cate.Pid && ac.Depth == 2).ToList();
                    }
                }
            }
            else
            {
                model.CateList = allCateList.Where(ac => ac.Depth == 1).ToList();
            }
            


     
            model.ProductList = _productService.GetList(search, pageIndex, pageSize).Items;
                                                                   
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

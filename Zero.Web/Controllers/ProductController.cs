﻿using System;
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
        public ICateService<Cate> _cateService;
        public ICateAttrService _cateAttrService;

        public ProductController(IProductService productService,
            ICateService<Cate> cateService,
            ICateAttrService cateAttrService)
        {
            _productService = productService;
            _cateService = cateService;
            _cateAttrService = cateAttrService;
        }

        public ActionResult Index()
        {
            ProductListModel model = new ProductListModel();
            ProductSearch productSearch = new ProductSearch();
            CateAttrSearch cateAttrSearch = new CateAttrSearch();
            productSearch.CateId = RequestHelper.AllInt("CateId");
            productSearch.Attr = RequestHelper.All("Attr");
            int pageSize = 30;
            int pageIndex = 0;

            //类别信息()
            List<Cate> allCateList = _cateService.GetList(0, 0);
            model.CateList = new List<List<Cate>>();

            if (productSearch.CateId > 0)
            {
                Cate cate = allCateList.SingleOrDefault(c => c.CateId == productSearch.CateId);

                if (cate != null)
                {
                    productSearch.Lid = cate.Lid;
                    productSearch.Rid = cate.Rid;

                    //获取分类路径
                    model.PathCateList = allCateList.Where(ac => ac.Lid <= cate.Lid && ac.Rid >= cate.Rid).ToList();

                    //获取1级分类
                    model.ParentCateList = allCateList.Where(ac => ac.Depth == 1).ToList();
                    
                    //根据路径加载相应的兄弟的节点

                    //获取分类信息
                    //if (cate.Depth == 1)
                    //{
                    //    model.CateList = allCateList.Where(ac => ac.Lid > cate.Lid && ac.Rid < cate.Rid && ac.Depth == 2).ToList();
                    //}
                    //else if (cate.Depth == 2)
                    //{
                    //    model.CateList = allCateList.Where(ac => ac.Pid == cate.Pid && ac.Depth == 2).ToList();
                    //}

                    foreach (var pathCate in model.PathCateList)
                    {
                        if (pathCate.Depth == 1)
                        {
                            model.CateList.Add(allCateList.Where(ac => ac.Depth == 1).ToList());
                        }

                        if (pathCate.Depth != 2)
                        {
                            model.CateList.Add(allCateList.Where(ac => ac.Pid == pathCate.CateId && ac.Depth == pathCate.Depth+1).ToList());
                        }
                    }


                    if (cate.Depth == 2)
                    {
                        //属性信息
                        cateAttrSearch.Lid = cate.Lid;
                        cateAttrSearch.Rid = cate.Rid;
                        model.CateAttrList = _cateAttrService.GetList(cateAttrSearch);
                    }
                }
            }
            else
            {
                model.CateList.Add(allCateList.Where(ac => ac.Depth == 1).ToList());
            }

            model.ProductSearch = productSearch;
            model.ProductList = _productService.GetList(productSearch, pageIndex, pageSize).Items;
                                                                   
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

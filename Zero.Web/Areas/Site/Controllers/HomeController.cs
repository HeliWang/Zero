using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net;
using System.IO;
using Zero.Web.Models;
using Zero.Service.News;
using Zero.Service.Products;
using Zero.Core.Web;

namespace Zero.Web.Areas.Site.Controllers
{
    public class HomeController : Controller
    {
        public IProductService _productService;
        public INewsService _newsService;

        public HomeController(IProductService productService,
           INewsService newsService)
        {
            _productService = productService;
            _newsService = newsService;
        }

        public ActionResult Index()
        {
            IndexModel indexModel = new IndexModel();
            indexModel.ProductList = _productService.GetList(8);
            indexModel.NewsList = _newsService.GetList(10);
            return View(indexModel);
        }

        public ActionResult GetAuthCode()
        {
            AuthCode authCode = new AuthCode();
            authCode.ImgWidth = 75;
            authCode.ImgHeight = 25;
            byte[] bytes = authCode.CreateAuthCode(4);
            return File(bytes, @"image/jpeg");
        }
    }
}

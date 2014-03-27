using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

using Zero.Core.Web;
using Zero.Core.Pattern;
using Zero.Domain.Products;
using Zero.Service.Products;
using Zero.Domain.Cates;
using Zero.Service.Cates;


namespace Zero.Mvc.Manage.Controllers.Products
{
    public class ProductController : BaseController
    {
        ProductService productService;

        public ProductController()
        {
            productService = Singleton<ProductService>.GetInstance();
        }

        public ActionResult ProductList()
        {
            int pageIndex = RequestHelper.QueryInt("page");
            int pageSize = RequestHelper.QueryInt("rows");

            pageIndex = pageIndex <= 0 ? 0 : pageIndex - 1;
            if (pageSize <= 0) pageSize = 10;

            IPage<Product> productPage = productService.GetList(pageIndex, pageSize);

            return Json(productPage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductIndex()
        {
            return View();
        }

        public ActionResult ProductAddPart()
        {
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ProductAdd(Product product)
        {
            ResultInfo resultInfo = new ResultInfo(1, "验证不通过");

            if (ModelState.IsValid)
            {
                ProductDesc productDetail = new ProductDesc();
                List<ProductPhoto> productPhotoList = new List<ProductPhoto>();
                List<Sku> skuList = new List<Sku>();

                resultInfo = productService.Add(product, productDetail, productPhotoList, skuList);
            }

            return Json(resultInfo);
        }

        public void GetFrom(Product product, ProductDesc productDesc, List<ProductPhoto> productPhotoList, List<Sku> skuList, StringBuilder errorMsg)
        {
            //基本信息
            FormItem<int> ProductIdItem = new FormItem<int>("ProductId", "产品编号", 0, 10, 0);
            FormItem<int> ProductTypeItem = new FormItem<int>("ProductType", "所属类型", 0, 3, 0);
            FormItem<string> ProductNameItem = new FormItem<string>("ProductName", "商品名称", 2, 30);
            FormItem<string> SubNameItem = new FormItem<string>("SubName", "商品卖点", 0, 30, "");
            FormItem<string> ZscItem = new FormItem<string>("Zsc", "商品编码", 0, 10,"");
            FormItem<decimal> PriceItem = new FormItem<decimal>("Price", "一口价", 0, 100000);
            FormItem<decimal> AmountItem = new FormItem<decimal>("Amount", "商品数量", 0, 100000);

            product.ProductId = ProductIdItem.GetFormValue(errorMsg);
            product.ProductType = ProductTypeItem.GetFormValue(errorMsg);
            product.ProductName = ProductNameItem.GetFormValue(errorMsg);
            product.SubName = SubNameItem.GetFormValue(errorMsg);
            product.Zsc = ZscItem.GetFormValue(errorMsg);
            product.Price = PriceItem.GetFormValue(errorMsg);
            product.Amount = AmountItem.GetFormValue(errorMsg);

            DateTime dt=DateTime.Now;
            product.CreateTime = dt;
            product.UpdateTime = dt;
            product.StartTime = dt;
            product.EndTime = dt;

            //产品说明
            FormItem<string> DescItem = new FormItem<string>("Desc", "商品详细", 0, 25000);

            productDesc.Desc = DescItem.GetFormValue(errorMsg);
        }
    }
}

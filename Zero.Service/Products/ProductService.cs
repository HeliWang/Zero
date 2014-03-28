using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zero.Data;
using Zero.Domain.Products;
using Zero.Core.Web;

namespace Zero.Service.Products
{
    public class ProductService
    {
        private IRepository<Product> _productRepository;

        public ProductService()
        {
            _productRepository = new EfRepository<Product>();
        }

        public ResultInfo Add(Product product, ProductDesc productDesc, List<ProductPhoto> productPhotoList, List<Sku> skuList)
        {
            product = _productRepository.Add(product);

            //if (productInfo != null)
            //{
            //    productDetailInfo.ProductId = productInfo.ProductId;
            //    _productDescMapper.Create(productDetailInfo);

            //    foreach (ProductPhotoInfo photoInfo in productPhotoList)
            //    {
            //        photoInfo.ProductId = productInfo.ProductId;
            //        _productPhotoMapper.Create(photoInfo);
            //    }

            //    foreach (SkuInfo skuInfo in skuList)
            //    {
            //        skuInfo.ProductId = productInfo.ProductId;
            //        _skuMapper.Create(skuInfo);
            //    }
            //}

            return new ResultInfo("添加成功");
        }

        public ResultInfo Edit(Product product, ProductDesc productDesc, List<ProductPhoto> productPhotoList, List<Sku> skuList)
        {
            _productRepository.Update(product);

            return new ResultInfo("修改成功");
        }

        public ResultInfo Delete(string ids)
        {
            Product product = _productRepository.GetById(Utils.StrToInt(ids));
            _productRepository.Delete(product);

            return new ResultInfo("删除成功");
        }

        public IPage<Product> GetList(int pageIndex, int pageSize)
        {
            var query = _productRepository.Table;
            query = query.OrderByDescending(b => b.CreateTime);
            return new Page<Product>(query, pageIndex, pageSize);
        }

        public Product GetById(int productId)
        {
            return _productRepository.GetById(productId);
        }

    }
}

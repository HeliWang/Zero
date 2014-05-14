﻿using System;
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
        private IRepository<Sku> _skuRepository;
        private IRepository<ProductDesc> _productDescRepository;
        private IRepository<ProductPhoto> _productPhotoRepository;

        public ProductService()
        {
            _productRepository = new EfRepository<Product>();
            _skuRepository = new EfRepository<Sku>();
            _productDescRepository = new EfRepository<ProductDesc>();
            _productPhotoRepository = new EfRepository<ProductPhoto>();
        }

        public ResultInfo Add(Product product)
        {
            var productId= _productRepository.Add(product).ProductId;

            //未测试是否有关联插入
            foreach (Sku sku in product.SkuList)
            {
                sku.ProductId = productId;
                _skuRepository.Add(sku);
            }

            foreach (ProductPhoto photo in product.PhotoList)
            {
                photo.ProductId = productId;
                _productPhotoRepository.Add(photo);
            }

            product.Desc.ProductId = productId;
            _productDescRepository.Add(product.Desc);

            return new ResultInfo("添加成功");
        }

        public ResultInfo Edit(Product product, ProductDesc productDesc, List<ProductPhoto> productPhotoList, List<Sku> skuList)
        {
            _productRepository.Update(product);
            return new ResultInfo("修改成功");
        }

        public ResultInfo Delete(string ids)
        {
            _productRepository.Delete(ids);
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
